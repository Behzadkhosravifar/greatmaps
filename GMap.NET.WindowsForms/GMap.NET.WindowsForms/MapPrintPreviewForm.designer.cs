using System.Drawing;
using System.Windows.Forms;

namespace GMap.NET.WindowsForms
{
    partial class MapPrintPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPrintPreviewForm));
            this.MapPanel = new System.Windows.Forms.Panel();
            this.gMap = new System.Windows.Forms.CustomGMapControl();
            this.docPrint = new System.Drawing.Printing.PrintDocument();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.dlgPageSetup = new System.Windows.Forms.PageSetupDialog();
            this.ScrollPanel = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.lblSpace2 = new System.Windows.Forms.ToolStripLabel();
            this.lblSpace = new System.Windows.Forms.ToolStripLabel();
            this.lblSpace3 = new System.Windows.Forms.ToolStripLabel();
            this.lblSpace5 = new System.Windows.Forms.ToolStripLabel();
            this.lblSpace4 = new System.Windows.Forms.ToolStripLabel();
            this.prgTileDownloadStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.cmbPaperSizes = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnChangeMapColor = new System.Windows.Forms.ToolStripButton();
            this.btnRotate = new System.Windows.Forms.ToolStripButton();
            this.btnShowHideMarkerInfo = new System.Windows.Forms.ToolStripButton();
            this.MapPanel.SuspendLayout();
            this.ScrollPanel.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.MapPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MapPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MapPanel.Controls.Add(this.gMap);
            this.MapPanel.Location = new System.Drawing.Point(15, 16);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MapPanel.Size = new System.Drawing.Size(1070, 730);
            this.MapPanel.TabIndex = 2;
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.ConnectionString = "";
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = true;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(5, 5);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = true;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(1060, 720);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            // 
            // docPrint
            // 
            this.docPrint.DocumentName = "چاپ نقشه";
            this.docPrint.OriginAtMargins = true;
            // 
            // dlgPrint
            // 
            this.dlgPrint.Document = this.docPrint;
            this.dlgPrint.UseEXDialog = true;
            // 
            // dlgPageSetup
            // 
            this.dlgPageSetup.Document = this.docPrint;
            this.dlgPageSetup.EnableMetric = true;
            // 
            // ScrollPanel
            // 
            this.ScrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollPanel.AutoScroll = true;
            this.ScrollPanel.Controls.Add(this.MapPanel);
            this.ScrollPanel.Location = new System.Drawing.Point(0, 77);
            this.ScrollPanel.Name = "ScrollPanel";
            this.ScrollPanel.Size = new System.Drawing.Size(1101, 761);
            this.ScrollPanel.TabIndex = 3;
            // 
            // menu
            // 
            this.menu.CanOverflow = false;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.lblSpace2,
            this.cmbPaperSizes,
            this.btnClose,
            this.lblSpace,
            this.btnChangeMapColor,
            this.lblSpace3,
            this.btnRotate,
            this.lblSpace5,
            this.btnShowHideMarkerInfo,
            this.lblSpace4,
            this.prgTileDownloadStatus});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(1101, 74);
            this.menu.TabIndex = 6;
            // 
            // lblSpace2
            // 
            this.lblSpace2.AutoSize = false;
            this.lblSpace2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lblSpace2.Name = "lblSpace2";
            this.lblSpace2.Size = new System.Drawing.Size(30, 71);
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = false;
            this.lblSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(30, 71);
            // 
            // lblSpace3
            // 
            this.lblSpace3.AutoSize = false;
            this.lblSpace3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lblSpace3.Name = "lblSpace3";
            this.lblSpace3.Size = new System.Drawing.Size(30, 71);
            // 
            // lblSpace5
            // 
            this.lblSpace5.AutoSize = false;
            this.lblSpace5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lblSpace5.Name = "lblSpace5";
            this.lblSpace5.Size = new System.Drawing.Size(30, 71);
            // 
            // lblSpace4
            // 
            this.lblSpace4.AutoSize = false;
            this.lblSpace4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lblSpace4.Name = "lblSpace4";
            this.lblSpace4.Size = new System.Drawing.Size(30, 71);
            // 
            // prgTileDownloadStatus
            // 
            this.prgTileDownloadStatus.AutoSize = false;
            this.prgTileDownloadStatus.MarqueeAnimationSpeed = 30;
            this.prgTileDownloadStatus.Name = "prgTileDownloadStatus";
            this.prgTileDownloadStatus.Size = new System.Drawing.Size(300, 40);
            this.prgTileDownloadStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgTileDownloadStatus.ToolTipText = "در حال بار گذاری نقشه";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = global::System.Windows.Forms.Properties.Resources.MapPrinter;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnPrint.Size = new System.Drawing.Size(75, 71);
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnPrint.ToolTipText = "چاپ نقشه";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbPaperSizes
            // 
            this.cmbPaperSizes.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaperSizes.Image = global::System.Windows.Forms.Properties.Resources.Document_xml_icon;
            this.cmbPaperSizes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmbPaperSizes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmbPaperSizes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmbPaperSizes.Name = "cmbPaperSizes";
            this.cmbPaperSizes.Size = new System.Drawing.Size(111, 71);
            this.cmbPaperSizes.Text = "A4";
            this.cmbPaperSizes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbPaperSizes.ToolTipText = "نوع صفحه";
            this.cmbPaperSizes.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmbPaperSizes_DropDownItemClicked);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::System.Windows.Forms.Properties.Resources.close_icon;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 71);
            this.btnClose.ToolTipText = "انصراف از چاپ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChangeMapColor
            // 
            this.btnChangeMapColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChangeMapColor.Image = global::System.Windows.Forms.Properties.Resources.MapPrintPreview;
            this.btnChangeMapColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnChangeMapColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeMapColor.Name = "btnChangeMapColor";
            this.btnChangeMapColor.Size = new System.Drawing.Size(63, 71);
            this.btnChangeMapColor.ToolTipText = "سیاه و سفید / رنگی";
            this.btnChangeMapColor.Click += new System.EventHandler(this.btnChangeMapColor_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotate.Image = global::System.Windows.Forms.Properties.Resources.Rotate2Portrait;
            this.btnRotate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(68, 71);
            this.btnRotate.ToolTipText = "چرخاندن صفحه";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnShowHideMarkerInfo
            // 
            this.btnShowHideMarkerInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideMarkerInfo.Image = global::System.Windows.Forms.Properties.Resources.ShowInfo;
            this.btnShowHideMarkerInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowHideMarkerInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideMarkerInfo.Name = "btnShowHideMarkerInfo";
            this.btnShowHideMarkerInfo.Size = new System.Drawing.Size(68, 71);
            this.btnShowHideMarkerInfo.ToolTipText = "نمایش / عدم نمایش بالون اطلاعات مشتری";
            this.btnShowHideMarkerInfo.Click += new System.EventHandler(this.btnShowHideMarkerInfo_Click);
            // 
            // MapPrintPreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1101, 838);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.ScrollPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapPrintPreviewForm";
            this.Text = "پیش نمایش چاپ";
            this.MapPanel.ResumeLayout(false);
            this.ScrollPanel.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel MapPanel;
        private System.Drawing.Printing.PrintDocument docPrint;
        private PrintDialog dlgPrint;
        public CustomGMapControl gMap;
        private PageSetupDialog dlgPageSetup;
        private Panel ScrollPanel;
        private ToolStrip menu;
        private ToolStripButton btnPrint;
        private ToolStripLabel lblSpace;
        private ToolStripDropDownButton cmbPaperSizes;
        private ToolStripButton btnClose;
        private ToolStripButton btnRotate;
        private ToolStripLabel lblSpace2;
        private ToolStripLabel lblSpace3;
        private ToolStripProgressBar prgTileDownloadStatus;
        private ToolStripLabel lblSpace4;
        private ToolStripButton btnChangeMapColor;
        private ToolStripLabel lblSpace5;
        private ToolStripButton btnShowHideMarkerInfo;
    }
}