﻿using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace AppMobile.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class home : AppCompatActivity
    {
        private Button btnsendHomeActivity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
            btnsendHomeActivity = FindViewById<Button>(Resource.Id.Activity_usuario);

            btnsendHomeActivity.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(homeActivity));
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                StartActivity(intent);
            };
        }

    }
}