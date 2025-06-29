using System.Windows;
using System.Windows.Controls;
using PsProjAleksandurTenev_501222019_49B.Model;
using PsProjAleksandurTenev_501222019_49B.Others;
using UI.Components;

namespace UI
{
    public partial class MainWindow : Window
    {
        private User _loggedInUser;
        private ContentControl _currentContentArea;

        public MainWindow()
        {
            InitializeComponent(); // This must be first
            _currentContentArea = MainContentArea; // Reference the XAML-defined control
            ShowLoginScreen();

            // Initialize button handlers
            btnAllUsers.Click += (s, e) => ShowContent(new AllUsersList(_loggedInUser)); 

            btnStudents.Click += (s, e) => ShowContent(new StudentsList());
            btnAddUser.Click += (s, e) => ShowContent(new AddUserControl());
        }

        private void ShowLoginScreen()
        {
            var loginControl = new LoginControl();
            loginControl.LoginSuccess += LoginControl_LoginSuccess;
            _currentContentArea.Content = loginControl;
        }

        private void LoginControl_LoginSuccess(object sender, UserLoginEventArgs e)
        {
            _loggedInUser = e.LoggedInUser;
            UpdateNavigationVisibility();
            ShowMainContentAfterLogin();
        }

        private void UpdateNavigationVisibility()
        {
            if (_loggedInUser == null)
            {
                btnAllUsers.Visibility = Visibility.Collapsed;
                btnAddUser.Visibility = Visibility.Collapsed;
                btnStudents.Visibility = Visibility.Collapsed;
                return;
            }

            btnAllUsers.Visibility = _loggedInUser.Roles == UserRolesEnum.ADMIN
                ? Visibility.Visible : Visibility.Collapsed;

            btnAddUser.Visibility = _loggedInUser.Roles == UserRolesEnum.ADMIN
                ? Visibility.Visible : Visibility.Collapsed;

            btnStudents.Visibility = (_loggedInUser.Roles == UserRolesEnum.ADMIN ||
                                     _loggedInUser.Roles == UserRolesEnum.PROFESSOR ||
                                     _loggedInUser.Roles == UserRolesEnum.INSPECTOR)
                ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ShowMainContentAfterLogin()
        {
            if (_loggedInUser.Roles == UserRolesEnum.ADMIN)
                ShowContent(new AddUserControl());
            else if (_loggedInUser.Roles == UserRolesEnum.PROFESSOR ||
                    _loggedInUser.Roles == UserRolesEnum.INSPECTOR)
                ShowContent(new StudentsList());
        }

        private void ShowContent(UserControl control)
        {
            _currentContentArea.Content = control;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;  // Clear logged in user info
            UpdateNavigationVisibility();  // This will hide the buttons again

            ShowLoginScreen();  // Show the login UserControl in the content area
        }

    }
}