using System;
using System.Collections.Generic;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using PsProjAleksandurTenev_501222019_49B.Model;
using PsProjAleksandurTenev_501222019_49B.Others;
using System.Linq;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using var userData = new UserData();

            while (true)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Показване на всички потребители");
                Console.WriteLine("2. Добавяне на потребител");
                Console.WriteLine("3. Изтриване на потребител");
                Console.WriteLine("4. Изход");
                Console.Write("Избери опция (1-4): ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n--- Всички потребители ---");
                        var allDbUsers = userData.GetAllUsers();

                        if (allDbUsers.Any())
                        {
                            foreach (var dbUser in allDbUsers)
                            {
                                User user = dbUser.ToUser();
                                Console.WriteLine($"ID: {user.Id}, Име: {user.Name}, Възраст: {user.Age}, Роля: {user.Roles}, Изтича: {user.Expires:dd.MM.yyyy}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Няма регистрирани потребители.");
                        }
                        break;

                    case "2":
                        Console.Write("\nВъведи потребителско име: ");
                        string newName = Console.ReadLine();

                        Console.Write("Въведи парола: ");
                        string newPassword = Console.ReadLine();

                        int newAge;
                        while (true)
                        {
                            Console.Write("Въведи възраст: ");
                            string ageInput = Console.ReadLine();

                            if (int.TryParse(ageInput, out newAge) && newAge >= 0)
                                break;
                            else
                                Console.WriteLine("Невалидна възраст. Моля, въведи положително цяло число.");
                        }

                        Console.WriteLine("Избери роля:");
                        foreach (UserRolesEnum roleValue in Enum.GetValues(typeof(UserRolesEnum)))
                        {
                            Console.WriteLine($"- {roleValue}");
                        }

                        Console.Write("Въведи роля (напр. ADMIN, STUDENT, PROFFESOR, INSPECTOR): ");
                        string roleInput = Console.ReadLine();
                        UserRolesEnum newRole;

                        if (!Enum.TryParse(roleInput, true, out newRole))
                        {
                            Console.WriteLine("Невалидна роля. Потребителят ще бъде създаден като STUDENT по подразбиране.");
                            newRole = UserRolesEnum.STUDENT;
                        }

                        var newUser = new User
                        {
                            Name = newName,
                            Password = newPassword,
                            Age = newAge,
                            Roles = newRole,
                            Expires = DateTime.Now.AddYears(1),
                            Id = userData.GetNextId()
                        };

                        userData.AddUser(newUser.ToDatabaseUser());
                        Console.WriteLine($"Потребителят '{newName}' с роля '{newRole}' и възраст '{newAge}' е добавен успешно.");
                        break;

                    case "3":
                        Console.Write("\nВъведи потребителско име за изтриване: ");
                        string delName = Console.ReadLine();

                        bool removed = userData.DeleteUserByName(delName);
                        if (removed)
                        {
                            Console.WriteLine("Потребителят е изтрит успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Не е намерен потребител с това име.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Изход от програмата.");
                        return;

                    default:
                        Console.WriteLine("Невалидна опция. Опитай отново.");
                        break;
                }
            }
        }
    }
}
