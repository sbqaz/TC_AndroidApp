using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TrafficControl.GUI
{
    [Activity(Label = "Kort")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        private MapFragment _myMapFragment;

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

            var location = new LatLng(56.460444, 10.037139);
            var builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(14);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            if (googleMap != null)
                googleMap.MoveCamera(cameraUpdate);
        }
    }
}