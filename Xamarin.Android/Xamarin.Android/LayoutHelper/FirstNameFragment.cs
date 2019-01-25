namespace Xamarin.Android.LayoutHelper
{
    using System;

    using global::Android.App;
    using global::Android.OS;
    using global::Android.Views;
    using global::Android.Widget;

    public class FirstNameFragment : Fragment
    {
        private View v = null;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            v = inflater.Inflate(Resource.Layout.firstNameFragment, container, false);
            var bundle = this.Arguments;
            EditText textView = null;
            var image = v.FindViewById<ImageView>(Resource.Id.imageView1);
            image.Click += OnClickImage;
            if (bundle != null)
            {
                var myString = bundle.GetString("firstName");
                textView = v.FindViewById<EditText>(Resource.Id.firstNameLabel);
                textView.SetText(myString.ToCharArray(), 0, myString.Length);
            }


            var content = textView.Text;
            return v;
        }

        private void OnClickImage(object sender, EventArgs e)
        {
            var bundle = this.Arguments;
            var textView = v.FindViewById<EditText>(Resource.Id.firstNameLabel);
            var fragment = new HomeFragment();
            var args = new Bundle();
            args.PutString("firstName", textView.Text);
            fragment.Arguments = args;
            FragmentManager.BeginTransaction()
                .SetCustomAnimations(Resource.Drawable.slider_from_right, Resource.Drawable.slider_to_left)
                .Replace(Resource.Id.content_frame, fragment).Commit();
        }
    }
}