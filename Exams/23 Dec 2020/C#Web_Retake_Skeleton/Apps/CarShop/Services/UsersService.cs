﻿using CarShop.Data;
using CarShop.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService: IUsersService
    {
        private readonly ApplicationDbContext db;
        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string username, string email, string password, string userType)
        {
            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
                IsMechanic = userType == "Mechanic" ? true : false
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

        public bool UserIsMechanic(string userId)
        {
            return this.db.Users.Any(u => u.Id == userId && u.IsMechanic);            
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