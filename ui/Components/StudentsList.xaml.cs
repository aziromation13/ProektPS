using System.Windows.Controls;
using UI.ViewModel;

namespace UI.Components
{
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();
            this.DataContext = new StudentsListViewModel();
        }
    }
}
