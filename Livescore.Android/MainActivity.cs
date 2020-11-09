using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.FacebookClient;
using Plugin.GoogleClient;
using Java.Security;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Gms.Auth.Api;
using Firebase;

namespace Livescore.Droid
{
    [Activity(Label = "Livescore", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            #region Generate HashKey - Do once, unless needing a newer one
            //try
            //{
            //    PackageInfo info = Android.App.Application.Context.PackageManager.GetPackageInfo(Android.App.Application.Context.PackageName, PackageInfoFlags.Signatures);
            //    foreach (var signature in info.Signatures)
            //    {
            //        MessageDigest md = MessageDigest.GetInstance("SHA");
            //        md.Update(signature.ToByteArray());

            //        //Facebook
            //        string st = "Facebook: " + Convert.ToBase64String(md.Digest());
            //        //Google
            //        string st2 = "Google: " + BitConverter.ToString(md.Digest()).Replace("-", ":");

            //    }
            //}
            //catch (NoSuchAlgorithmException e)
            //{
            //    System.Diagnostics.Debug.WriteLine(e);
            //}
            //catch (Exception e)
            //{
            //    System.Diagnostics.Debug.WriteLine(e);
            //}
            #endregion

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //Initialize Socal plugins
            FacebookClientManager.Initialize(this);
            GoogleClientManager.Initialize(this);

            

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            //Facebook
            FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
            //Google
            GoogleClientManager.OnAuthCompleted(requestCode, resultCode, intent);
        }
    }
}