using Food_Journal.ClientApi.Controllers;
using Food_Journal.Shared.Utils;
using Food_Journal.Shared.Helpers;
using System;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;
using Food_Journal.Shared.Constants;
using Food_Journal.Shared.Services;
using GalaSoft.MvvmLight.Views;

namespace Food_Journal.Shared.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public LoginPageViewModel(
            IApplicationState applicationState,
            IUserController userController,
            INavigationService navigationService)
        {
            _applicationState = applicationState;
            _userController = userController;
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(_Login);
            CreateUserCommand = new DelegateCommand(_CreateUser);
        }

        readonly IApplicationState _applicationState;
        readonly IUserController _userController;
        readonly INavigationService _navigationService;

        public ICommand LoginCommand { get; }
        public ICommand CreateUserCommand { get; }

        string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        async void _Login()
        {
            try
            {
                IsBusy = true;
                var isSuccess = false;
                try
                {
                    var hashedPassword = CryptoHelper.HashPassword(Password);
                    var loggedInUser = await _userController.LoginUser(Username, hashedPassword);

                    if (loggedInUser != null)
                    {
                        _applicationState.CurrentUser = loggedInUser;
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                }
                
                if (!isSuccess)
                {
                    ErrorMessage = "Error: Username and password do not match";
                    Password = string.Empty;
                }
                else
                {
                    Username = string.Empty;
                    Password = string.Empty;

                    _navigationService.NavigateTo(PageTokens.EntriesListPage);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        void _CreateUser()
        {
            _navigationService.NavigateTo(PageTokens.RegisterPage);
        }
    }
}
