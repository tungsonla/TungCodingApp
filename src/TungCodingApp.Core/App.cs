using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TungCodingApp.Core.ViewModels.Main;

namespace TungCodingApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainActivityViewModel>();
        }
    }
}
