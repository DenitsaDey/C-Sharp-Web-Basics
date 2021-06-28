using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db) => this.db = db;

        public void Create(RegisterUserInputModel input)
        {
            var newUser = new User
            {
                Username = input.Username,
                Email = input.Email,
                Password = ComputeHash(input.Password),
            };

            this.db.Users.Add(newUser);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = ComputeHash(password);
            return this.db.Users
                .FirstOrDefault(u => u.Username == username
                                  && u.Password == hashedPassword)?.Id;
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(u => u.Username == username);
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(u => u.Email == email);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
