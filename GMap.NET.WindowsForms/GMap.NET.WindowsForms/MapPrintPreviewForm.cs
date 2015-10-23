using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using GMap.NET.ObjectModel;
using System.Threading;
using GMap.NET.WindowsForms.Markers;

namespace GMap.NET.WindowsForms
{
    public partial class MapPrintPreviewForm : Form
    {
        #region Properties

        public bool CanCloseAfterPrint { get; set; }
        public Image MapImage { get; private set; }
        public PaperSize PageSize
        {
            get { return dlgPageSetup.PageSettings.PaperSize; }
            set
            {
                dlgPageSetup.PageSettings.PaperSize = value;

                RefreshPaper();
            }
        }
        public bool Landscape
        {
            get { return dlgPageSetup.PageSettings.Landscape; }
            set
            {
                dlgPageSetup.PageSettings.Landscape = value;

                RefreshPaper();
            }
        }
        public bool ShowMarkerInfo { get; set; }

        protected Margins MapPaperMergins { get; set; }
        protected Margins ScrollingMergins { get; set; }
        protected PictureBox picPageSizeInfo { get; set; }

        protected readonly AutoResetEvent done = new AutoResetEvent(true);

        #endregion


        #region Constructors

        protected MapPrintPreviewForm()
        {
            InitializeComponent();

            MapPaperMergins = new Margins(100, 100, 100, 100);
            ScrollingMergins = new Margins(80, 80, 80, 80);
            dlgPageSetup.PageSettings.Landscape = true;
            PageSize = PaperSizes.A4;
            docPrint.PrintPage += docPrint_PrintPage;
            dlgPageSetup.PageSettings.Margins = new Margins(30, 35, 30, 30);
            ShowMarkerInfo = true;

            InitializePageSizes();
        }


        public MapPrintPreviewForm(GMapControl ctrlGMap)
            : this()
        {
            #region Create Map copied

            gMap.Manager.Mode = AccessMode.ServerOnly;
            gMap.MinZoom = ctrlGMap.MinZoom;
            gMap.MaxZoom = ctrlGMap.MaxZoom;
            gMap.Zoom = ctrlGMap.Zoom;
            gMap.Position = ctrlGMap.Position;
            gMap.MouseWheelZoomEnabled = ctrlGMap.MouseWheelZoomEnabled;
            gMap.MouseWheelZoomType = ctrlGMap.MouseWheelZoomType;
            gMap.EmptyTileColor = System.Drawing.Color.Aquamarine;
            gMap.GrayScaleMode = true;
            gMap.Manager.UsePlacemarkCache = false;
            gMap.ConnectionString = (ctrlGMap is CustomGMapControl)
                ? ((CustomGMapControl)ctrlGMap).ConnectionString
                : null;
            gMap.OnTileLoadComplete += GMap_OnTileLoadComplete;
            gMap.OnTileLoadStart += GMap_OnTileLoadStart;
            gMap.Manager.UseMemoryCache = true;

            //gMap.Manager.CancelTileCaching();

            foreach (GMapOverlay overlay in ctrlGMap.Overlays)
            {
                foreach (var marker in overlay.Markers)
                {
                    gMap.AddMarker(marker);
                }

                foreach (var route in overlay.Routes)
                {
                    var r = new GMapRoute(route.Name);
                    r.Points.AddRange(route.Points);
                    r.Stroke = route.Stroke;

                    gMap.AddRoute(r);
                }

                gMap.SetMapBound();
            }

            #endregion            
        }

        #endregion

        #region Methods

        private void GMap_OnTileLoadStart()
        {
            if (!IsDisposed)
            {
                done.Reset();

                this.InvokeIfRequired(() => prgTileDownloadStatus.Visible = true);
                this.InvokeIfRequired(() => btnRotate.Enabled = false);
            }
        }

        private void GMap_OnTileLoadComplete(long elapsedMilliseconds)
        {
            if (!IsDisposed)
            {
                done.Set();

                this.InvokeIfRequired(() => prgTileDownloadStatus.Visible = false);
                this.InvokeIfRequired(() => btnRotate.Enabled = true);
            }
        }

        private void docPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(MapImage, 0, 0);
            MapImage.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MapImage = gMap.PrintInvisibleControl();

            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {
                docPrint.Print();

                if (CanCloseAfterPrint)
                    Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbPaperSizes_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var kind = e.ClickedItem.Text;

            cmbPaperSizes.Text = kind;

            PageSize = PaperSizes.GetPaperSize(kind);
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            Landscape = !Landscape;
            btnRotate.Image = Landscape
                ? System.Windows.Forms.Properties.Resources.Rotate2Portrait
                : System.Windows.Forms.Properties.Resources.Rotate2Landscape;
        }

        public void RefreshPaper()
        {
            ScrollPanel.AutoScrollMinSize = Landscape
                    ? new Size(dlgPageSetup.PageSettings.PaperSize.Height - ScrollingMergins.Top,
                        dlgPageSetup.PageSettings.PaperSize.Width - ScrollingMergins.Left)
                    : new Size(dlgPageSetup.PageSettings.PaperSize.Width - ScrollingMergins.Left,
                        dlgPageSetup.PageSettings.PaperSize.Height - ScrollingMergins.Top);

            MapPanel.Size = Landscape
                    ? new Size(PageSize.Height - MapPaperMergins.Top, PageSize.Width - MapPaperMergins.Left)
                    : new Size(PageSize.Width - MapPaperMergins.Left, PageSize.Height - MapPaperMergins.Top);


            var mapX = (ScrollPanel.Width - MapPanel.Width) / 2;
            var mapY = (ScrollPanel.Height - MapPanel.Height) / 2;

            //
            // Set ScrollPanel.Scroll to position Zero 0
            ScrollPanel.AutoScrollPosition = new Point(0, 0);

            MapPanel.Left = mapX < 10 ? 10 : mapX;
            MapPanel.Top = mapY < 10 ? 10 : mapY;

        }

        private void btnChangeMapColor_Click(object sender, EventArgs e)
        {
            gMap.GrayScaleMode = !gMap.GrayScaleMode;
        }

        private void InitializePageSizes()
        {
            picPageSizeInfo = new PictureBox();
            picPageSizeInfo.Image = (Image)System.Windows.Forms.Properties.PageResource.ResourceManager.GetObject("A4");
            picPageSizeInfo.Dock = DockStyle.Fill;
            picPageSizeInfo.BackColor = Color.Transparent;
            picPageSizeInfo.SizeMode = PictureBoxSizeMode.CenterImage;

            cmbPaperSizes.DropDownClosed += (s, e) => ScrollPanel.Controls.Remove(picPageSizeInfo);
            cmbPaperSizes.DropDownOpened += (s, e) =>
            {
                ScrollPanel.Controls.Add(picPageSizeInfo);
                picPageSizeInfo.BringToFront();
            };

            foreach (var property in typeof(PaperSizes).GetProperties())
            {
                var item = cmbPaperSizes.DropDownItems.Add(property.Name);
                item.MouseEnter += (sender, e) =>
                {
                    var hoverText = ((ToolStripDropDownItem)sender).Text;
                    picPageSizeInfo.Image = (Image)System.Windows.Forms.Properties.PageResource.ResourceManager.GetObject(hoverText);
                };
            }
        }

        private void btnShowHideMarkerInfo_Click(object sender, EventArgs e)
        {
            ShowMarkerInfo = !ShowMarkerInfo;

            btnShowHideMarkerInfo.Image = ShowMarkerInfo
                ? System.Windows.Forms.Properties.Resources.ShowInfo
                : System.Windows.Forms.Properties.Resources.HideInfo;

            foreach (var layer in gMap.Overlays)
                foreach (var marker in layer.Markers)
                    marker.ToolTipMode = ShowMarkerInfo
                        ? MarkerTooltipMode.Always
                        : MarkerTooltipMode.OnMouseOver;

            gMap.Refresh();
        }

        #endregion

    }
}