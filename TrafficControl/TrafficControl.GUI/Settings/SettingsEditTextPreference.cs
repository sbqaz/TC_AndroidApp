using System;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TrafficControl.GUI.Settings
{
    public class SettingsEditTextPreference : EditTextPreference
    {
        private TextView _valueText;

        public SettingsEditTextPreference(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            LayoutResource = Resource.Layout.preference_with_value;
        }

        public SettingsEditTextPreference(Context context) : base(context)
        {
            LayoutResource = Resource.Layout.preference_with_value;
        }

        public SettingsEditTextPreference(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            LayoutResource = Resource.Layout.preference_with_value;
        }

        public SettingsEditTextPreference(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            LayoutResource = Resource.Layout.preference_with_value;
        }

        public SettingsEditTextPreference(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            LayoutResource = Resource.Layout.preference_with_value;
        }

        protected override void OnBindView(View view)
        {
            base.OnBindView(view);
            TextView titleView = view.FindViewById<TextView>(Android.Resource.Id.Title);
            titleView.SetTextColor(view.Resources.GetColor(Resource.Color.ForeGround));

            _valueText = view.FindViewById<TextView>(Resource.Id.preference_value);
            if (_valueText != null)
            {
                _valueText.Text = Text;
            }
        }
    }
}