using System;
using System.Collections.Generic;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Adapters;
using TrafficControl.GUI.Map;

namespace TrafficControl.GUI
{
    [Activity(Label = "Kort")]
    public class MapActivity : Activity, IOnMapReadyCallback, GoogleMap.IOnInfoWindowClickListener, IMapView
    {
        private MapFragment _myMapFragment;
        private MapMarkerFactory _mapMarkerFactory;
        private GoogleMap _googleMap;
        private IMapPresenter _presenter;
        private string[] _mapMarkerStrings = new[] { "Green", "Yellow", "Red" };
        private Dictionary<string, Installation> _installations;

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

            _installations = new Dictionary<string, Installation>();

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
                _googleMap.SetInfoWindowAdapter(new MapMarkerAdapter(LayoutInflater, _installations));
                _googleMap.SetOnInfoWindowClickListener(this);
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

        public void AddMapMarker(Installation installation)
        {
            _installations.Add(installation.Id.ToString(), installation);

            _googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(installation.Position.Latitude, installation.Position.Longtitude))
                    .SetTitle(installation.Address)
                    .SetSnippet(installation.Id.ToString())
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(_mapMarkerFactory.GetMapMarker(_mapMarkerStrings[installation.Status])))
                    );
        }

        public void OnInfoWindowClick(Marker marker)
        {
            Toast.MakeText(this, marker.Title, ToastLength.Short).Show();
        }
    }
}