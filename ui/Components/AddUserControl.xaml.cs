using System.Windows.Controls;
using UI.ViewModel;

namespace UI.Components
{
    public partial class AddUserControl : UserControl
    {
        private readonly AddUserViewModel viewModel;

        public AddUserControl()
        {
            InitializeComponent();

            viewModel = new AddUserViewModel();
            this.DataContext = viewModel;

            NewUserPasswordBox.PasswordChanged += (s, e) =>
            {
                viewModel.NewUserPassword = NewUserPasswordBox.Password;
            };
        }
    }
}
