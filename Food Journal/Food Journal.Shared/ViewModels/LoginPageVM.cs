using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Food_Journal.ClientApi.Controllers;
using Food_Journal.Shared.Utils;

namespace Food_Journal.Shared.ViewModels
{
    public class LoginPageVM : BindableBase
    {
        public LoginPageVM(IUserController userController)
        {
            _userController = userController;

            LoginCommand = new DelegateCommand(_Login);
            CreateUserCommand = new DelegateCommand(_CreateUser);
        }

        IUserController _userController;

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

        bool _isBusy;

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
                var results = await _userController.GetUsers();

                var loggedInUser = results.FirstOrDefault(u => u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase)
                                                      && u.Password == Password);

                if (loggedInUser == null)
                {
                    ErrorMessage = "Error: Username and password do not match";
                    Password = string.Empty;
                }
                else
                {
                    Username = string.Empty;
                    Password = string.Empty;
                    
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        void _CreateUser()
        {

        }
    }
}
