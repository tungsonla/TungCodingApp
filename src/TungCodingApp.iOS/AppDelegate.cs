using Foundation;
using MvvmCross.Platforms.Ios.Core;
using TungCodingApp.Core;

namespace TungCodingApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
