using System;
using System.Collections.Generic;
using System.ComponentModel;              
using System.Linq;
using System.Windows.Input;               
using System.Windows.Media;               
using PsProjAleksandurTenev_501222019_49B.Model;     
using PsProjAleksandurTenev_501222019_49B.Others;    
using UI.Components;                     
using WelcomeExtended.Data;               
using WelcomeExtended.Helpers;            

namespace UI.ViewModel
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private string _newUserName;
        public string NewUserName
        {
            get => _newUserName;
            set
            {
                _newUserName = value;
                OnPropertyChanged(nameof(NewUserName));
                ((RelayCommand)AddUserCommand).RaiseCanExecuteChanged();
            }
        }

        private string _newUserPassword;
        public string NewUserPassword
        {
            get => _newUserPassword;
            set
            {
                _newUserPassword = value;
                OnPropertyChanged(nameof(NewUserPassword));
                ((RelayCommand)AddUserCommand).RaiseCanExecuteChanged();
            }
        }

        private int _newUserAge;
        public int NewUserAge
        {
            get => _newUserAge;
            set
            {
                _newUserAge = value;
                OnPropertyChanged(nameof(NewUserAge));
                ((RelayCommand)AddUserCommand).RaiseCanExecuteChanged();
            }
        }

        private UserRolesEnum _selectedRole;
        public UserRolesEnum SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }

        private DateTime? _expiresDate;
        public DateTime? ExpiresDate
        {
            get => _expiresDate;
            set
            {
                _expiresDate = value;
                OnPropertyChanged(nameof(ExpiresDate));
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        private SolidColorBrush _statusMessageColor;
        public SolidColorBrush StatusMessageColor
        {
            get => _statusMessageColor;
            set
            {
                _statusMessageColor = value;
                OnPropertyChanged(nameof(StatusMessageColor));
            }
        }

        public List<UserRolesEnum> AvailableRoles { get; set; }
        public ICommand AddUserCommand { get; }

        public AddUserViewModel()
        {
            AvailableRoles = Enum.GetValues(typeof(UserRolesEnum)).Cast<UserRolesEnum>().ToList();
            SelectedRole = UserRolesEnum.STUDENT;
            ExpiresDate = DateTime.Now.AddYears(1);
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
            NewUserAge = 18; 
        }

        private bool CanAddUser(object parameter)
        {
            return !string.IsNullOrWhiteSpace(NewUserName)
                && !string.IsNullOrWhiteSpace(NewUserPassword)
                && NewUserAge > 0;
        }

        private void AddUser(object parameter)
        {
            try
            {
                using var userData = new UserData();

                if (userData.GetAllUsers().Any(u => u.Name.Equals(NewUserName, StringComparison.OrdinalIgnoreCase)))
                {
                    StatusMessage = "User already exists.";
                    StatusMessageColor = Brushes.Red;
                    return;
                }

                var newUser = new User
                {
                    Name = NewUserName,
                    Password = NewUserPassword,
                    Roles = SelectedRole,
                    Expires = ExpiresDate ?? DateTime.Now.AddYears(1),
                    Id = userData.GetNextId(),
                    Age = NewUserAge
                };

                userData.AddUser(newUser.ToDatabaseUser());

                StatusMessage = $"User '{NewUserName}' added successfully!";
                StatusMessageColor = Brushes.Green;

                
                NewUserName = string.Empty;
                NewUserPassword = string.Empty;
                SelectedRole = UserRolesEnum.STUDENT;
                ExpiresDate = DateTime.Now.AddYears(1);
                NewUserAge = 18;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                StatusMessageColor = Brushes.Red;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
