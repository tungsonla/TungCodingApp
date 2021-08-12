using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TungCodingApp.Core.Services;

namespace TungCodingApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IUsersService _usersService;
        private ObservableCollection<User> _usersCollection;
        public ObservableCollection<User> UsersCollection
        {
            get => _usersCollection;
            set
            {
                _usersCollection = value;
                RaisePropertyChanged(() => UsersCollection);
            }
        }

        public MainViewModel(IUsersService usersService)
        {
            _usersService = usersService;
            LoadData();
        }

        public void LoadData()
        {
            List<User> users = _usersService.LoadUsers();
            UsersCollection = new ObservableCollection<User>(users);
        }
    }
}
