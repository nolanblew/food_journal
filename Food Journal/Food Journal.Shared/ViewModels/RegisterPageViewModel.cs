using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Food_Journal.ClientApi.Controllers;
using Food_Journal.DB.Models;
using Food_Journal.Shared.Services;
using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;

namespace Food_Journal.Shared.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        public RegisterPageViewModel(
            IApplicationState applicationState,
            IUserController userController,
            INavigationService navigationService)
        {
            _applicationState = applicationState;
            _userController = userController;
            _navigationService = navigationService;

            CreateUserCommand = new DelegateCommand(_CreateUser);
        }

        private readonly IApplicationState _applicationState;
        private readonly IUserController _userController;
        private readonly INavigationService _navigationService;

        public ICommand CreateUserCommand { get; }

        User _newUser = new User();

        public User NewUser
        {
            get { return _newUser; }
            set { SetProperty(ref _newUser, value); }
        }

        string _potentialPassword;

        public string PotentialPassword
        {
            get { return _potentialPassword; }
            set { SetProperty(ref _potentialPassword, value); }
        }

        string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        async void _CreateUser()
        {
            try
            {
                IsBusy = true;

                var validResult = await _isUserValidAsync();
                if (!validResult.IsValid)
                {
                    ErrorMessage = validResult.ErrorMessage;
                    IsBusy = false;
                    return;
                }

                NewUser.Password = Helpers.CryptoHelper.HashPassword(PotentialPassword);
                try
                {
                    var loggedInUser = await _userController.CreateUser(NewUser);
                    _applicationState.CurrentUser = loggedInUser;
                    await new MessageDialog($"Welcome, {_applicationState.CurrentUser.Name}!").ShowAsync();
                    _navigationService.GoBack();
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error: {ex.Message}";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task<(bool IsValid, string ErrorMessage)> _isUserValidAsync()
        {
            if (NewUser.Name.Length < 4)
            {
                return (false, "Please enter your full name.");
            }

            if (string.IsNullOrEmpty(NewUser.Username))
            {
                return (false, "Please enter a username.");
            }

            if (NewUser.Username.Length < 5)
            {
                return (false, "Please enter a username 5 characters or more.");
            }

            if (PotentialPassword.Length < 5)
            {
                return (false, "Please enter a password 5 characters or more.");
            }

            if (await _userController.UsernameExists(NewUser.Username))
            {
                return (false, "Username is already taken.");
            }

            return (true, null);
        }
    }
}
