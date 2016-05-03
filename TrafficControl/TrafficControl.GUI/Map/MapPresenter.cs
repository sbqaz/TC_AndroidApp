using TrafficControl.BLL.Map;

namespace TrafficControl.GUI.Map
{
    public class MapPresenter :IMapPresenter
    {
        private readonly IMapView _view;
        private readonly IMapModel _model;

        public MapPresenter(IMapView view, IMapModel model)
        {
            _view = view;
            _model = model;
        }

        public void MapReady()
        {
            _view.SetCameraDefaultPosition();
            _view.AddMapMarker(56.460444, 10.037139, "Green");
        }
    }
}