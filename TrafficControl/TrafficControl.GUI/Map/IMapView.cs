namespace TrafficControl.GUI.Map
{
    public interface IMapView
    {
        void SetCameraDefaultPosition();
        void AddMapMarker(double latitude, double longitude, string markerType);
    }
}