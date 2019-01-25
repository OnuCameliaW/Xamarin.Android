using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4;
namespace Xamarin.Android.LayoutHelper
{
    using global::Android.Media.Audiofx;

    using Xamarin.Android.Models;

    public class HomeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.homeFragment, container, false);
            var firstNameLayout = v.FindViewById<LinearLayout>(Resource.Id.linearLayoutFirstName);
            var firstNameValue = v.FindViewById<TextView>(Resource.Id.firstNameValue);

            var bundle = this.Arguments;
            if (bundle != null)
            {
                UserSettings.FirstName = bundle.GetString("firstName");
               
            }

            firstNameValue.SetText(UserSettings.FirstName.ToCharArray(), 0, UserSettings.FirstName.Length);

            firstNameLayout.Click += OnClickFirstName;
            return v;
        }

        private void OnClickFirstName(object sender, EventArgs e)
        {
            var fragment = new FirstNameFragment();
            var args = new Bundle();
            args.PutString("firstName", UserSettings.FirstName);
            fragment.Arguments = args;
            FragmentManager.BeginTransaction()
                .AddToBackStack("FirstNameFragment")
                .SetCustomAnimations(Resource.Drawable.slider_left, Resource.Drawable.slider_right)
                .Replace(Resource.Id.content_frame, fragment).Commit();
        }
    }
}