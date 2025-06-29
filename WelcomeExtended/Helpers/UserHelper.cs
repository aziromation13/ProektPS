using System;
using DataLayer.Model;
using PsProjAleksandurTenev_501222019_49B.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        
        public static User ToUser(this DatabaseUser dbUser)
        {
            if (dbUser == null) return null;

            return new User
            {
                Id = dbUser.Id,
                Name = dbUser.Name,
                Password = dbUser.Password,
                Roles = dbUser.Roles,
                Expires = dbUser.Expires,
                Age = dbUser.Age    
            };
        }

        
        public static DatabaseUser ToDatabaseUser(this User user)
        {
            if (user == null) return null;

            return new DatabaseUser
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Roles = user.Roles,
                Expires = user.Expires,
                Age = user.Age    
            };
        }

        
        public static string ToUserString(this User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            return $"User ID: {user.Id}, Name: {user.Name}, Age: {user.Age}, Role: {user.Roles}, Expires: {user.Expires:dd.MM.yyyy}";
        }

        
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("The password cannot be empty", nameof(password));

            return userData.ValidateUser(name, password);
        }

        
        public static User GetUser(this UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("The password cannot be empty", nameof(password));

            var dbUser = userData.GetUser(name, password);
            return dbUser.ToUser();
        }
    }
}
