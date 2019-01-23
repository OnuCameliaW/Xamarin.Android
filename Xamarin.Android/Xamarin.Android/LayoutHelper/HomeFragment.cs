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

    public class HomeFragment : Fragment
    {
        private String textValue = "";
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
            textValue = "Cami";
            if (bundle != null)
            {
                textValue = bundle.GetString("firstName");
               
            }

            firstNameValue.SetText(textValue.ToCharArray(), 0, textValue.Length);

            firstNameLayout.Click += OnClickFirstName;
            return v;
        }

        private void OnClickFirstName(object sender, EventArgs e)
        {
            var fragment = new FirstNameFragment();
            var args = new Bundle();
            args.PutString("firstName", this.textValue);
            fragment.Arguments = args;
            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }
    }
}