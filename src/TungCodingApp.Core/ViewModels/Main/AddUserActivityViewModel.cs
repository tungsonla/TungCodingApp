using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using TungCodingApp.Core.Services;

namespace TungCodingApp.Core.ViewModels.Main
{
    public class AddUserActivityViewModel : BaseViewModel
    {
        private string _title = "Add User";
        private readonly IUsersService _usersService;
        private readonly IMvxNavigationService _mvxNavigationService;
        private string _name;
        private string _password;
        private string _nameMessage;
        private string _passwordMessage;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }

        }

        public string NameMessage
        {
            get => _nameMessage;
            set
            {
                _nameMessage = value;
                RaisePropertyChanged(() => NameMessage);
            }
        }

        public string PasswordMessage
        {
            get => _passwordMessage;
            set
            {
                _passwordMessage = value;
                RaisePropertyChanged(() => PasswordMessage);
            }

        }

        public AddUserActivityViewModel(IUsersService usersService, IMvxNavigationService mvxNavigationService)
        {
            _usersService = usersService;
            _mvxNavigationService = mvxNavigationService;
        }

        public IMvxCommand CancelCommand => new MvxCommand(() =>
        {
            _mvxNavigationService.Navigate<MainActivityViewModel>();
        });

        public IMvxCommand SaveCommand => new MvxCommand(() =>
        {
            if (InputValidations() == true)
            {
                _usersService.AddUser(Name, Password);
                _mvxNavigationService.Navigate<MainActivityViewModel>();
            }
        });

        /// <summary>
        /// Input Validations
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        private bool InputValidations()
        {
            NameMessage = string.Empty;
            PasswordMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Name))
            {
                NameMessage = "Please enter user name";
                return false;
            }

            if (_usersService.IsUserNameExists(Name))
            {
                NameMessage = "User name already exists.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordMessage = "Please enter user password";
                return false;
            }

            if (Password.Length < 5 || Password.Length > 12)
            {
                PasswordMessage = "Password must be between 5 and 12 characters in length.";
                return false;
            }

            if (!Regex.IsMatch(Password, @"\d"))
            {
                PasswordMessage = "Password must contain at least 1 digit.";
                return false;
            }

            if (!Regex.IsMatch(Password, @"[a-zA-Z]"))
            {
                PasswordMessage = "Password must contain at least 1 letter.";
                return false;
            }

            if (Regex.IsMatch(Password, @"(.+)\1"))
            {
                PasswordMessage = "Password must not contain any sequence of characters immediately followed by the same sequence.";
                return false;
            }

            return true;
        }
    }
}
