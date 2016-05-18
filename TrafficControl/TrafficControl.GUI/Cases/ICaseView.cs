namespace TrafficControl.GUI.Cases
{
    public interface ICaseView
    {
        void SetContentViewCreated();
        void SetContentViewStarted();
        void SetContentViewPending();
        void SetContentViewDone();
    }
}