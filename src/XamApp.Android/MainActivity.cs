﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Bit.Droid;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PageDesign.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using PageDesign.Contracts;
using PageDesign.Droid.Implementations;
using Xamarin.Forms;

namespace PageDesign.Droid
{
    [Activity(Label = "PageDesign", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : BitFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("ee74db97-563c-48cd-a1a3-aaf403fe1cc4", typeof(Crashes), typeof(Analytics));

            BitExceptionHandler.Current = new XamAppExceptionHandler();

            base.OnCreate(savedInstanceState);

            UseDefaultConfiguration(savedInstanceState);
            UserDialogs.Init(this);
            Forms.Init(this, savedInstanceState);

            LoadApplication(new PageDesign.App(new XamAppPlatformInitializer(this)));
        }
    }

    public class XamAppPlatformInitializer : BitPlatformInitializer
    {
        public XamAppPlatformInitializer(Activity activity)
            : base(activity)
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerBuilder.RegisterType<AndroidAppVersionService>()
                .As<IAppVersionService>()
                .PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

            base.RegisterTypes(containerRegistry);
        }
    }
}
