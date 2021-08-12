using System;

using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using TungCodingApp.Core;

namespace TungCodingApp.Droid
{
    #if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
        public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
