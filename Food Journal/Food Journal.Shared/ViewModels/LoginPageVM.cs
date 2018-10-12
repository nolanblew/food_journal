using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Food_Journal.Shared.Utils;

namespace Food_Journal.Shared.ViewModels
{
    public class LoginPageVM : BindableBase
    {
        public LoginPageVM()
        {
            LoginCommand = new DelegateCommand(_Login);
            CreateUserCommand = new DelegateCommand(_CreateUser);
        }

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
                await Task.Delay(TimeSpan.FromSeconds(5));
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
