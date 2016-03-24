using System;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TrafficControl.GUI.Settings
{
    public class SettingsPreferenceCategory : PreferenceCategory
    {
        public SettingsPreferenceCategory(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SettingsPreferenceCategory(Context context) : base(context)
        {
        }

        public SettingsPreferenceCategory(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SettingsPreferenceCategory(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public SettingsPreferenceCategory(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
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