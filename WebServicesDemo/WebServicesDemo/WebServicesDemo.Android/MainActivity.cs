using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps.Model;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Android.Support.V4.Content;
using Android;
using System.Collections.Generic;

namespace WebServicesDemo.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        List<string> _permission = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //Xamarin.FormsMap.Init(this,bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);
            RequestPermissionsManually();
            LoadApplication(new App());
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        //{
        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        private void RequestPermissionsManually()
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.AccessFineLocation);
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.AccessCoarseLocation);
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.Camera);
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.ReadExternalStorage);
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.WriteExternalStorage);
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadPhoneState) != Android.Content.PM.Permission.Granted)
                    _permission.Add(Manifest.Permission.ReadPhoneState);
                if (_permission.Count > 0)
                {
                    string[] array = _permission.ToArray();
                    RequestPermissions(array, array.Length);
                }
            }
            catch (System.Exception ex)
            {
            }
        }


    }
}

