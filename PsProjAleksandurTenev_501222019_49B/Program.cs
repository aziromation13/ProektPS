using PsProjAleksandurTenev_501222019_49B.Model;
using PsProjAleksandurTenev_501222019_49B.View;
using PsProjAleksandurTenev_501222019_49B.ViewModel;

namespace PsProjAleksandurTenev_501222019_49B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User diddy = new User();
            diddy.Name = "Diddy";
            diddy.Password = "password";
            diddy.Roles = Others.UserRolesEnum.ANONYMOUS;

            UserViewModel UvM = new UserViewModel(diddy);
            UserView Uv = new UserView(UvM);
            Uv.Display();
            Console.ReadKey();


        }
    }
}
