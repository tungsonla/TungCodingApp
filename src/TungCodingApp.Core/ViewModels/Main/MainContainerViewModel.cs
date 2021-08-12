using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TungCodingApp.Core.Services;

namespace TungCodingApp.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
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

        public MainContainerViewModel(IUsersService usersService)
        {
            _usersService = usersService;
            LoadData();
        }

        public void LoadData()
        {
            UsersCollection = new ObservableCollection<User>(_usersService.LoadUsers());
        }
    }
    
}
