using System.Windows.Controls;
using PsProjAleksandurTenev_501222019_49B.Model; // for User
using UI.ViewModel; // for AllUsersListViewModel

namespace UI.Components
{
    public partial class AllUsersList : UserControl
    {
        public AllUsersList(User currentUser)
        {
            InitializeComponent();
            this.DataContext = new AllUsersListViewModel(currentUser);
        }
    }
}
