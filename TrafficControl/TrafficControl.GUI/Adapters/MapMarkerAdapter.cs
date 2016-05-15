using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Adapters
{
    public class MapMarkerAdapter : Java.Lang.Object, GoogleMap.IInfoWindowAdapter
    {
        private readonly LayoutInflater _inflater;
        private readonly Dictionary<string, Installation> _installations;
        private View _view = null;

        public MapMarkerAdapter(LayoutInflater inflater, Dictionary<string, Installation> installations)
        {
            _inflater = inflater;
            _installations = installations;
        }

        public View GetInfoContents(Marker marker)
        {
            var tmpInstallation = _installations[marker.Snippet];

            _view = _inflater.Inflate(Resource.Layout.MapItem, null);
            var installationName = _view.FindViewById<TextView>(Resource.Id.item_name);
            var installationLatitude = _view.FindViewById<TextView>(Resource.Id.item_latitude);
            var installationLongitude = _view.FindViewById<TextView>(Resource.Id.item_longitude);
            installationName.Text = tmpInstallation.Name;
            installationLatitude.Text = string.Format("Breddegrad: {0}", tmpInstallation.Position.Latitude);
            installationLongitude.Text = string.Format("Længdegrad: {0}", tmpInstallation.Position.Longtitude);

            return _view;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}