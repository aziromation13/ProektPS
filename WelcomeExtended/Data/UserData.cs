using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using PsProjAleksandurTenev_501222019_49B.Others;

namespace WelcomeExtended.Data
{
    public class UserData : IDisposable
    {
        private readonly DatabaseContext _dbContext;

        public UserData()
        {
            _dbContext = new DatabaseContext();
            _dbContext.Database.EnsureCreated();
        }

        public void AddUser(DatabaseUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool ValidateUser(string name, string password)
        {
            return _dbContext.Users.Any(u => u.Name == name && u.Password == password);
        }

        public DatabaseUser GetUser(string name, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public void SetActive(string name, DateTime date)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Expires = date;
                _dbContext.SaveChanges();
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Roles = role;
                _dbContext.SaveChanges();
            }
        }

        public List<DatabaseUser> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public bool DeleteUserByName(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int GetNextId()
        {
            if (_dbContext.Users.Any())
                return _dbContext.Users.Max(u => u.Id) + 1;
            else
                return 1;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void DeleteUser(int userId)
        {
            using var context = new DatabaseContext(); // ✅ Create an instance
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void DeleteAllUsersExcept(int userIdToKeep)
        {
            using var context = new DatabaseContext();
            var usersToDelete = context.Users.Where(u => u.Id != userIdToKeep).ToList();
            context.Users.RemoveRange(usersToDelete);
            context.SaveChanges();
        }
    }
}
