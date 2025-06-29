using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsProjAleksandurTenev_501222019_49B.ViewModel;

namespace PsProjAleksandurTenev_501222019_49B.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: " + _viewModel.UserName);
            Console.WriteLine("User: " + _viewModel.Roles);
        }

        public static void DisplayError()
        {
            throw new Exception("Грешка от потребителския изглед!");
        }
    }
}
