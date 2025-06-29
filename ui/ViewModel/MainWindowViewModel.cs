using System.ComponentModel;              
using System.Windows.Input;              
using PsProjAleksandurTenev_501222019_49B.Model;     
using PsProjAleksandurTenev_501222019_49B.Others;    
using UI.Components;                     

namespace UI.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User _loggedInUser;
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        
        public ICommand ShowUsersCommand { get; private set; }
        public ICommand ShowStudentsCommand { get; private set; }
        public ICommand ShowAddUserCommand { get; private set; }

        public MainWindowViewModel()
        {
           
            CurrentView = new LoginViewModel(OnLoginSuccess);
        }

        private void OnLoginSuccess(User user)
        {
            _loggedInUser = user;

            ShowUsersCommand = new RelayCommand(o => CurrentView = new AllUsersList(_loggedInUser), o => IsAdmin);
            ShowStudentsCommand = new RelayCommand(o => CurrentView = new StudentsListViewModel(), o => IsAuthorizedForStudents);
            ShowAddUserCommand = new RelayCommand(o => CurrentView = new AddUserViewModel(), o => IsAdmin);

        
            OnPropertyChanged(nameof(ShowUsersCommand));
            OnPropertyChanged(nameof(ShowStudentsCommand));
            OnPropertyChanged(nameof(ShowAddUserCommand));

           
            if (IsAdmin) ShowAddUserCommand.Execute(null);
            else if (IsAuthorizedForStudents) ShowStudentsCommand.Execute(null);
        }

        private bool IsAdmin => _loggedInUser?.Roles == UserRolesEnum.ADMIN;
        private bool IsAuthorizedForStudents =>
            _loggedInUser?.Roles is UserRolesEnum.ADMIN or UserRolesEnum.PROFESSOR or UserRolesEnum.INSPECTOR;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
