using System.Windows.Input;
using Food_Journal.ClientApi.Controllers;
using Food_Journal.DB.Models;
using Food_Journal.Shared.Services;
using Food_Journal.Shared.Utils;

namespace Food_Journal.Shared.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        public RegisterPageViewModel(
            IApplicationState applicationState,
            IUserController userController)
        {
            _applicationState = applicationState;
            _userController = userController;

            CreateUserCommand = new DelegateCommand(_CreateUser);
        }

        private readonly IApplicationState _applicationState;
        private readonly IUserController _userController;

        public ICommand CreateUserCommand { get; }

        User _newUser = new User();

        public User NewUser
        {
            get { return _newUser; }
            set { SetProperty(ref _newUser, value); }
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

        void _CreateUser()
        {
            throw new System.NotImplementedException();
        }

        bool _isUserValid(out string message)
        {
            if (NewUser.Name.Length < 4)
            {
                message = "Please enter your full name.";
                return false;
            }

            if (string.IsNullOrEmpty(NewUser.Username))
            {
                message = "Please enter a username.";
                return false;
            }

            if (NewUser.Username.Length < 5)
            {
                message = "Please enter a username 5 characters or more.";
                return false;
            }

            if (NewUser.Password.Length < 5)
            {
                message = "Please enter a password 5 characters or more.";
            }



            message = string.Empty;
            return true;
        }
    }
}
