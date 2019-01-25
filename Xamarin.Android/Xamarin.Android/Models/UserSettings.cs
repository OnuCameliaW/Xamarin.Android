using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin.Android.Models
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string FirstName
        {
            get => AppSettings.GetValueOrDefault(nameof(FirstName), "Cami");
            set => AppSettings.AddOrUpdateValue(nameof(FirstName), value);
        }
        public static void ClearAllData()
        {
            AppSettings.Clear();
        }
    }
}