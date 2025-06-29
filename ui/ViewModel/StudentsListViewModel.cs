using System.Collections.ObjectModel;
using System.ComponentModel;
using PsProjAleksandurTenev_501222019_49B.Model;
using PsProjAleksandurTenev_501222019_49B.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

namespace UI.ViewModel
{
    public class StudentsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> StudentUsers { get; set; }

        public StudentsListViewModel()
        {
            using var userData = new UserData();
            var dbUsers = userData.GetAllUsers();
            var students = dbUsers
                .ConvertAll(u => u.ToUser())
                .Where(u => u.Roles == UserRolesEnum.STUDENT)
                .ToList();

            StudentUsers = new ObservableCollection<User>(students);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
