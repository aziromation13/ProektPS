using System.Windows.Controls;
using UI.ViewModel;

namespace UI.Components
{
    public partial class LoginControl : UserControl
    {
        private readonly LoginViewModel viewModel;

        public LoginControl()
        {
            InitializeComponent();

            viewModel = new LoginViewModel(OnLoginSuccess);
            this.DataContext = viewModel;

            pwdBox.PasswordChanged += (s, e) => viewModel.Password = pwdBox.Password;
        }

        private void OnLoginSuccess(PsProjAleksandurTenev_501222019_49B.Model.User user)
        {
            LoginSuccess?.Invoke(this, new UserLoginEventArgs { LoggedInUser = user });
        }

        public event EventHandler<UserLoginEventArgs> LoginSuccess;
    }

    public class UserLoginEventArgs : EventArgs
    {
        public PsProjAleksandurTenev_501222019_49B.Model.User LoggedInUser { get; set; }
    }
}
