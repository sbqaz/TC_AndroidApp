using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Map
{
    public interface IMapView
    {
        void SetCameraDefaultPosition();
        void AddMapMarker(Installation installation);
    }
}