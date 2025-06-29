using System.ComponentModel;              
using System.Windows;                     
using System.Windows.Input;               
using PsProjAleksandurTenev_501222019_49B.Model;     
using UI.Components;                      
using WelcomeExtended.Data;               
using WelcomeExtended.Helpers;


namespace UI.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly Action<User> _onLoginSuccess;

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }

        public ICommand LoginCommand { get; }

        public LoginViewModel(Action<User> onLoginSuccess)
        {
            _onLoginSuccess = onLoginSuccess;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object obj)
        {
            using var userData = new UserData();
            var dbUser = userData.GetUser(Username, Password);
            if (dbUser != null && userData.ValidateUser(Username, Password))
                _onLoginSuccess(dbUser.ToUser());
            else
                MessageBox.Show("Invalid credentials.");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
