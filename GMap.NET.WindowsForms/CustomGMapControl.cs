using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms.GMap.NET.ObjectModel;
using GMap.NET;
using GMap.NET.CacheProviders;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace System.Windows.Forms
{
    /// <summary>
    /// Customize GMap for IRAN country
    /// </summary>
    public class CustomGMapControl : GMapControl
    {
        private readonly GMapOverlay _officeMarkersOverlay;
        private readonly GMapOverlay _markersOverlay;
        private MsSQLPureImageCache _cache;
        private GMapRoundedToolTip _selectedTooltip;

        /// <summary>
        /// Define MsSQL cache connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return (_cache != null) ? _cache.ConnectionString : string.Empty;
            }
            set
            {
                if (_cache != null) _cache.ConnectionString = value;
            }
        }


        /// <summary>
        /// CustomGMapControl Constructor
        /// </summary>
        public CustomGMapControl()
        {
            if (!IsDesignerHosted)
            {
                _officeMarkersOverlay = new GMapOverlay("officeMarkers");
                _markersOverlay = new GMapOverlay("markers");
                _cache = new MsSQLPureImageCache();

                Overlays.Add(_officeMarkersOverlay);
                Overlays.Add(_markersOverlay);
                Manager.BoostCacheEngine = true;
                Manager.PrimaryCache = _cache;
                //Manager.SecondaryCache = _cache;
                FillEmptyTiles = true;
                RenderMode = RenderMode.GDI_PLUS;
                Bearing = 0.0F;
                CanDragMap = true;
                EmptyTileColor = System.Drawing.Color.Navy;
                GrayScaleMode = false;
                HelperLineOption = HelperLineOptions.DontShow;
                LevelsKeepInMemmory = 5;
                MarkersEnabled = true;
                MouseWheelZoomEnabled = true;
                MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
                NegativeMode = false;
                PolygonsEnabled = true;
                RetryLoadTile = 1;
                RoutesEnabled = true;
                ScaleMode = ScaleModes.Integer;
                ShowTileGridLines = false;
                MapProvider = GMapProviders.GoogleMap;
                MinZoom = 3;
                MaxZoom = 19;
                IgnoreMarkerOnMouseWheel = true;
                ForceDoubleBuffer = true;
                MapScaleInfoEnabled = true;
                Manager.UseRouteCache = true;
                Position = new PointLatLng(38.03539973326430, 46.41332030296330);

                // set your proxy here if need
                //GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
                //GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");

                // map events
                #region Map Events

                //gmap.OnPositionChanged += new PositionChanged(gmap_OnPositionChanged);

                //gmap.OnTileLoadStart += new TileLoadStart(gmap_OnTileLoadStart);
                //gmap.OnTileLoadComplete += new TileLoadComplete(gmap_OnTileLoadComplete);

                //gmap.OnMapZoomChanged += new MapZoomChanged(gmap_OnMapZoomChanged);
                //gmap.OnMapTypeChanged += new MapTypeChanged(gmap_OnMapTypeChanged);

                //gmap.OnMarkerClick += new MarkerClick(gmap_OnMarkerClick);
                //gmap.OnMarkerEnter += new MarkerEnter(gmap_OnMarkerEnter);
                //gmap.OnMarkerLeave += new MarkerLeave(gmap_OnMarkerLeave);

                //gmap.OnPolygonEnter += new PolygonEnter(gmap_OnPolygonEnter);
                //gmap.OnPolygonLeave += new PolygonLeave(gmap_OnPolygonLeave);

                //gmap.OnRouteEnter += new RouteEnter(gmap_OnRouteEnter);
                //gmap.OnRouteLeave += new RouteLeave(gmap_OnRouteLeave);

                //gmap.Manager.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
                //gmap.Manager.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
                //gmap.Manager.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);

                #endregion
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && gxOff != null)
            {
                for (int index = _markersOverlay.Markers.Count - 1; index >= 0; index--)
                {
                    var markerPos = FromLatLngToLocal(_markersOverlay.Markers[index].Position);

                    var tooltip = (GMapRoundedToolTip)_markersOverlay.Markers[index].ToolTip;

                    if (tooltip.IsMouseOver(gxOff, e.Location, markerPos))
                    {
                        _selectedTooltip = tooltip;
                        _selectedTooltip.StartMouseDrag(e);
                        return;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left && _selectedTooltip != null)
            {
                _selectedTooltip.StopMouseDrag();
                _selectedTooltip = null;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left && _selectedTooltip != null && gxOff != null)
            {
                _selectedTooltip.OnMouseDrag(gxOff, e);
                Refresh();
            }
        }

        public async Task InitializeAsync()
        {
            await Task.Delay(1);

            try
            {
                IPHostEntry ping = Dns.GetHostEntry("www.google.com");
                this.InvokeIfRequired(() => Manager.Mode = AccessMode.ServerAndCache);
            }
            catch
            {
                this.InvokeIfRequired(() => Manager.Mode = AccessMode.CacheOnly);
                //MessageBox.Show("No internet connection available, going to CacheOnly mode.",
                //    "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            // TODO delete below test code:
            //AddMarker(new CustomerMarker()
            //{
            //    DistributeOrder = 1,
            //    Id = 1,
            //    Name = "دفتر پخش تبریز",
            //    Latitude = (decimal)38.03539973326430,
            //    Longitude = (decimal)46.41332030296330
            //});
        }


        /// <summary>
        /// Add customer marker on the Map
        /// </summary>
        /// <param name="customer">Position and marker info</param>
        public void AddMarker(CustomerMarker customer)
        {
            if (customer.Latitude != null && customer.Longitude != null)
            {
                var marker = new GMarkerGoogle(new PointLatLng((double)customer.Latitude, (double)customer.Longitude), GMarkerGoogleType.red);
                marker.ToolTip = new GMapRoundedToolTip(marker);

                marker.ToolTipText = customer.Name;
                marker.ToolTipMode = MarkerTooltipMode.Always;

                _markersOverlay.Markers.Add(marker, customer.DistributeOrder);
            }
        }

        /// <summary>
        /// Add customer marker on the Map
        /// </summary>
        /// <param name="customer">Position and marker info</param>
        public void AddMarker(GMapMarker gMarker)
        {
            var marker = new GMarkerGoogle(gMarker.Position, GMarkerGoogleType.red);
            marker.ToolTip = new GMapRoundedToolTip(marker);

            if (gMarker.ToolTip != null)
            {
                marker.Offset = gMarker.ToolTip.Offset;
                marker.ToolTipText = gMarker.ToolTipText;
                marker.ToolTipMode = MarkerTooltipMode.Always;
            }

            _markersOverlay.Markers.Add(marker, gMarker.SortedIndex);
        }


        /// <summary>
        /// Add list of customer markers on the Map
        /// </summary>
        /// <param name="positions"></param>
        public void AddRangeMarker(IEnumerable<CustomerMarker> positions)
        {
            foreach (var latLng in positions)
            {
                AddMarker(latLng);
            }

            ResetAllRoutesAsync();
            SetMapBound();
        }

        /// <summary>
        /// Add customer marker on the Map
        /// </summary>
        /// <param name="position">Position of marker</param>
        public void AddOfficeMarker(PointLatLng position)
        {
            var marker = new GMarkerGoogle(position, GMarkerGoogleType.blue_dot);
            _officeMarkersOverlay.Markers.Add(marker);
        }

        /// <summary>
        /// Add list of customer markers on the Map
        /// </summary>
        /// <param name="positions"></param>
        public void AddRangeOfficeMarker(IEnumerable<PointLatLng> positions)
        {
            foreach (var latLng in positions)
            {
                AddOfficeMarker(latLng);
            }
        }

        protected async Task<GMapRoute> GetRouteByOpenStreetMapAsync(PointLatLng start, PointLatLng end, string routeName)
        {
            return await Task.Run<GMapRoute>(() =>
            {
                MapRoute route = OpenStreetMapProvider.Instance.GetRoute(start, end, false, false, (int)Zoom);

                if (route != null)
                {
                    GMapRoute r = new GMapRoute(route.Points, routeName);
                    //r.Stroke.Width = 3;
                    //r.Stroke.Color = Drawing.Color.OrangeRed;
                    //double distance = route.Distance;
                    return r;
                }

                return null;
            });
        }

        public async void ResetAllRoutesAsync()
        {
            _markersOverlay.Routes.Clear();

            var markers = _markersOverlay.Markers.GetSortedList();

            for (int index = 0; markers.Count > 1 && index < markers.Count - 1; index++)
            {
                var routeName = string.Format("{0}-{1}", index, index + 1);
                var route = await GetRouteByOpenStreetMapAsync(markers[index].Position, markers[index + 1].Position, routeName);
                if (route != null)
                {
                    this.InvokeIfRequired(() => _markersOverlay.Routes.Add(route));
                }
            }
        }

        public void AddRoute(GMapRoute route)
        {
            if (route != null)
            {
                this.InvokeIfRequired(() => _markersOverlay.Routes.Add(route));
            }
        }

        public void Clear()
        {
            _markersOverlay.Clear();
        }

        public void SetMapBound()
        {
            ZoomAndCenterMarkers(_markersOverlay.Id);

            ZoomAndCenterRoutes(_markersOverlay.Id);
        }


    }
}
