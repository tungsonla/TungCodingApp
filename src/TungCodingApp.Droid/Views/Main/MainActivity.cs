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
using TungCodingApp.Core.ViewModels.Main;

namespace TungCodingApp.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainActivity : BaseActivity<MainActivityViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main;
    }
}
