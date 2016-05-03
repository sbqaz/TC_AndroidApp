using System;
using System.Collections.Generic;
using Android.Content.Res;
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

            _view = _inflater.Inflate(Resource.Layout.CaseItem, null);
            var installationName = _view.FindViewById<TextView>(Resource.Id.case_name);
            var installationId = _view.FindViewById<TextView>(Resource.Id.case_id);
            var installationTime = _view.FindViewById<TextView>(Resource.Id.case_time);
            var installationIcon = _view.FindViewById<ImageView>(Resource.Id.CaseIcon);
            installationName.Text = tmpInstallation.Address;
            installationId.Text = string.Format("ID: {0}", tmpInstallation.Id);
            installationTime.Text = tmpInstallation.Name;
            
            switch (tmpInstallation.Status)
            {
                case 0:
                    installationIcon.SetImageResource(Resource.Drawable.TCLogoGreen);
                    break;
                case 1:
                    installationIcon.SetImageResource(Resource.Drawable.TCLogoYellow);
                    break;
                case 2:
                    installationIcon.SetImageResource(Resource.Drawable.TCLogoRed);
                    break;
            }

            return _view;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}