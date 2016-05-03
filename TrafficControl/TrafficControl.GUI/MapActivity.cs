using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using TrafficControl.BLL;
using TrafficControl.GUI.Map;

namespace TrafficControl.GUI
{
    [Activity(Label = "Kort")]
    public class MapActivity : Activity, IOnMapReadyCallback, IMapView
    {
        private MapFragment _myMapFragment;
        private MapMarkerFactory _mapMarkerFactory;
        private GoogleMap _googleMap;
        private IMapPresenter _presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Map);

            if (savedInstanceState == null)
            {
                _myMapFragment = MapFragment.NewInstance();
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                tx.Add(Resource.Id.MapContentFrame, _myMapFragment);
                tx.Commit();
            }
            _mapMarkerFactory = new MapMarkerFactory(Resources);
            _presenter = new MapPresenter(this, ModelFactory.Instance.CreateMapModel());
            _myMapFragment.GetMapAsync(this);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MapsInitializer.Initialize(this);

            _googleMap = googleMap;

            if (_googleMap != null)
            {
                _presenter.MapReady();
            }
        }

        public void SetCameraDefaultPosition()
        {
            var location = new LatLng(56.460444, 10.037139); //Randers
            var builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(14);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            
            _googleMap.MoveCamera(cameraUpdate);
        }

        public void AddMapMarker(double latitude, double longitude, string markerType)
        {
            //TODO Change title to installation name/ID
            _googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(latitude, longitude))
                    .SetTitle("Traffic Control")  
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(_mapMarkerFactory.GetMapMarker(markerType))));
        }
    }
}