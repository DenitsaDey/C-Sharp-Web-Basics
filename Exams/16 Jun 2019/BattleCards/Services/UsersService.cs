﻿using SulsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SulsApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password)
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string passowrd)
        {
            var passwordHash = ComputeHash(passowrd);
            var user = this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);
            return user?.Id;
            //return user == null ? null : user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(user => user.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(user => user.Username == username);
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
