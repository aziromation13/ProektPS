using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsProjAleksandurTenev_501222019_49B.Model;
using PsProjAleksandurTenev_501222019_49B.Others;

namespace PsProjAleksandurTenev_501222019_49B.ViewModel
{
    public class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }

        public string UserName { get { return _user.Name; } set { _user.Name = value; } }
        public string Password { get { return _user.Password; } set { _user.Password = value; } }
        public UserRolesEnum Roles
        {
            get { return _user.Roles; }
            set { _user.Roles = value; }



        }
    }

}
