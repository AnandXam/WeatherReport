
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherReportShared.ViewModel;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;
using Org.W3c.Dom;
using AndroidX.AppCompat.App;
using Android.Graphics.Drawables;
using static Android.Content.Res.Resources;
using Android.Support.V7.App;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherReport.Activities
{
    [Activity(Label = "SunRiseActivity", Theme = "@style/AppTheme")]
    public class SunRiseActivity : AndroidX.AppCompat.App.AppCompatActivity
    {
        public static IServiceProvider Service { get; set; }
        SuriseViewModel suriseViewModel { get; set; }
        TextView sunriseText, sunrsetText;
        private LottieAnimationView SunriseAnimation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sunrise);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            Service = WeatherReportShared.Startup.Init();
            suriseViewModel = Service.GetService<SuriseViewModel>();
            this.SunriseAnimation = FindViewById<LottieAnimationView>(Resource.Id.SunriseAnimation);
            this.SunriseAnimation.PlayAnimation();
            this.sunriseText = FindViewById<TextView>(Resource.Id.sunriseText);
            this.sunrsetText = FindViewById<TextView>(Resource.Id.sunsetText);
            Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#0F0F39"));
            suriseViewModel.Initialize();
            sunriseText.Text = suriseViewModel.Sunrise;
            sunrsetText.Text = suriseViewModel.Sunset;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // check if the current item id 
            // is equals to the back button id
            if (item.ItemId == 16908332) // xam forms nav bar back button id
            {
                base.OnBackPressed();

                return true;
            }
            else
            {
                // since its not the back button 
                //click, pass the event to the base
                return base.OnOptionsItemSelected(item);
            }
        }

    }
}

