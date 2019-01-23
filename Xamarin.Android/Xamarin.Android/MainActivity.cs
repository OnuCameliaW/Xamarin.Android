using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Xamarin.Android
{
    using Xamarin.Android.LayoutHelper;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            // Load the first fragment on creation
            LoadFragment(Resource.Id.homeFragment);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

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
                FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, aFragment).Commit();
            }

            return false;
        }
    }
}

