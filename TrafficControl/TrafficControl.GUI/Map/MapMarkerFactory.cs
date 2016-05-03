using System.Collections;
using Android.Content.Res;
using Android.Graphics;

namespace TrafficControl.GUI.Map
{
    public class MapMarkerFactory
    {
        private readonly Hashtable _mapMarkers = new Hashtable();
        public MapMarkerFactory(Resources res)
        {
            _mapMarkers.Add("Green", Scale(BitmapFactory.DecodeResource(res, Resource.Drawable.TCLogoGreen)));
            _mapMarkers.Add("Yellow", Scale(BitmapFactory.DecodeResource(res, Resource.Drawable.TCLogoYellow)));
            _mapMarkers.Add("Red", Scale(BitmapFactory.DecodeResource(res, Resource.Drawable.TCLogoRed)));
        }

        private Bitmap Scale(Bitmap icon)
        {
            return Bitmap.CreateScaledBitmap(icon, icon.Width * 4 / 10, icon.Height * 4 / 10, false);
        }

        public Bitmap GetMapMarker(string key)
        {
            return ((Bitmap)_mapMarkers[key]);
        }
    }
}