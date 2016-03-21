using Android.Views;

namespace TrafficControl.GUI.Menu
{
    public interface IMenuPresenter
    {
        bool OnCreateOptionsMenu(MenuInflater menuInflater, IMenu menu);
        bool OnOptionsItemSelected(IMenuItem item);
    }
}