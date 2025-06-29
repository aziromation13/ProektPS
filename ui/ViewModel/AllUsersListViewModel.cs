using PsProjAleksandurTenev_501222019_49B.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using UI.Components;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

public class AllUsersListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<User> Users { get; set; }
    public ICommand DeleteAllUsersCommand { get; }
    public User CurrentUser { get; set; }

    public AllUsersListViewModel(User currentUser)
    {
        CurrentUser = currentUser;
        LoadUsers();
        DeleteAllUsersCommand = new RelayCommand(DeleteAllUsers);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private void LoadUsers()
    {
        using var userData = new UserData();
        var dbUsers = userData.GetAllUsers();
        Users = new ObservableCollection<User>(dbUsers.ConvertAll(u => u.ToUser()));
        OnPropertyChanged(nameof(Users));
    }

    private void DeleteAllUsers(object obj)
    {
        try
        {
            using var userData = new UserData();
            userData.DeleteAllUsersExcept(CurrentUser.Id); 
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error deleting users: " + ex.Message);
        }
    }
}
