namespace Xamarin.Android
{
    using System;

    using global::Android.App;
    using global::Android.OS;
    using global::Android.Support.Design.Widget;
    using global::Android.Support.V7.App;
    using global::Android.Views;
    using global::Android.Widget;

    using Xamarin.Android.LayoutHelper;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public bool LoadFragment(int item)
        {
            Fragment aFragment = null;
            switch (item)
            {
                case Resource.Id.navigation_home:
                    aFragment = new HomeFragment();
                    break;
                case Resource.Id.navigation_dashboard:
                    aFragment = new DashboardFragment();
                    break;
                case Resource.Id.navigation_notifications:
                    aFragment = new NotificationFragment();
                    break;
            }

            if (aFragment != null)
            {
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, aFragment).Commit();
            }

            return false;
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back)
            {
                Toast.MakeText(this, "Back button blocked", ToastLength.Short).Show();
                return false;
            }

            Toast.MakeText(this, "Button press allowed", ToastLength.Short).Show();
            return true;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var navigation = this.FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += this.BottomNavigation_NavigationItemSelected;

            // Load the first fragment on creation
            this.LoadFragment(Resource.Id.homeFragment);

            var backButton = FindViewById<Button>(Resource.Id.toolbarBackButton);
            backButton.Click += OnBackPressed;
        }

        public void OnBackPressed(Object sender, EventArgs e)
        {
            FragmentManager.PopBackStackImmediate();
            //var fragmentsarray = SupportFragmentManager.Fragments;
            //foreach (var fragment in fragmentsarray)
            //{
            //    if (fragment.IsVisible)
            //    {
            //        //put the code to use and get the tag to identify the current Fragment
            //        string tag = fragment.Tag;

            //    }
            //}
        }
        

        private void SetBackButtonInvisible()
        {
            var backButton = FindViewById<Button>(Resource.Id.toolbarBackButton);
            backButton.Visibility = ViewStates.Gone;
        }

        private void BottomNavigation_NavigationItemSelected(
            object sender,
            BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            this.LoadFragment(e.Item.ItemId);
        }
    }
}