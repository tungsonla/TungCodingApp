using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using TungCodingApp.Core.Services;

namespace TungCodingApp.Core.ViewModels.Main
{
    public class MainActivityViewModel : BaseViewModel
    {
        private string _title = "Users List";
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly IUsersService _usersService;
        private ObservableCollection<User> _usersCollection;
        private List<string> _usersCollectionx;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }

        }

        public ObservableCollection<User> UsersCollection
        {
            get => _usersCollection;
            set
            {
                _usersCollection = value;
                RaisePropertyChanged(() => UsersCollection);
            }
        }

        public MainActivityViewModel(IUsersService usersService, IMvxNavigationService mvxNavigationService)
        {
            _usersService = usersService;
            _mvxNavigationService = mvxNavigationService;
            LoadData();
        }

        public void LoadData()
        {
            List<User> users = _usersService.LoadUsers();
            UsersCollection = new ObservableCollection<User>(users);
        }

        public IMvxCommand AddUser => new MvxCommand(() =>
                                                    {
                                                        _mvxNavigationService.Navigate<AddUserActivityViewModel>();
                                                    });

    }
}
