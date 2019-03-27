﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Speech.Tts;
using Android.Gms.Gcm;
using Android.Content;

namespace AISCM.Droid
{
    [Activity(Label = "KRISHI VIKAS", Icon = "@drawable/logo", LaunchMode = LaunchMode.SingleTop, Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        
    {

        public string email = "";
        
        protected override void OnCreate(Bundle bundle)
        {
            
              TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(bundle);

            //net.azurewebsites.aiscm.WebService1 w = new net.azurewebsites.aiscm.WebService1();
            //string s = w.HelloWorld();
            //System.Diagnostics.Debug.WriteLine(s);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            LoadApplication(new App());
            System.Diagnostics.Debug.WriteLine("Email===");
            System.Diagnostics.Debug.WriteLine(Global_portable.email);
           // Global_portable.email = "desai.mangala@gmail.com";
            //Global_portable.email = "aditya.sd12@gmail.com";
            if (Global_portable.email!=null)
             {
                var intent = new Intent(this, typeof(RegistrationIntentService));
                StartService(intent);
                switch (Global_portable.user_id)
                {
                    //system admin
                    case 1:
                        //Xamarin.Forms.NavigationPage np1 = new Xamarin.Forms.NavigationPage(new homepage());

                        break;
                    //farmer login
                    case 2:
                        Xamarin.Forms.NavigationPage np2 = new Xamarin.Forms.NavigationPage(new index());
                        break;
                    //manufacturing company login
                    case 3:
                        Xamarin.Forms.NavigationPage np3 = new Xamarin.Forms.NavigationPage(new CropMarketView());
                        break;
                    //market admin login
                }
             }
             else
             {
                StartActivity(typeof(Login));
             }
        }
        
    }
}

