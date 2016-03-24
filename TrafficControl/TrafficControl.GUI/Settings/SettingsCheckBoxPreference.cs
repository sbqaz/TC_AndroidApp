using System;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TrafficControl.GUI.Settings
{
    public class SettingsCheckBoxPreference : CheckBoxPreference
    {
        public SettingsCheckBoxPreference(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SettingsCheckBoxPreference(Context context) : base(context)
        {
        }

        public SettingsCheckBoxPreference(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SettingsCheckBoxPreference(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public SettingsCheckBoxPreference(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override void OnBindView(View view)
        {
            base.OnBindView(view);
            TextView titleView = view.FindViewById<TextView>(Android.Resource.Id.Title);
            titleView.SetTextColor(view.Resources.GetColor(Resource.Color.ForeGround));
        }
    }
}