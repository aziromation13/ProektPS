using PsProjAleksandurTenev_501222019_49B.Others;
using System;

namespace DataLayer.Model
{
    public class DatabaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
        public UserRolesEnum Roles { get; set; }

        public int Age { get; set; }  
    }
}
