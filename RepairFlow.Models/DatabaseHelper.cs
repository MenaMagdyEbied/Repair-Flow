using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RepairFlow.Models
{
    // Simple JSON-backed user store to avoid external DB dependencies
    public static class DatabaseHelper
    {
        private static readonly string DataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
        private static readonly object _lock = new object();
        private static bool _initialized = false;

        public static void InitializeDatabase()
        {
            if (_initialized) return;
            lock (_lock)
            {
                if (!File.Exists(DataFile))
                {
                    File.WriteAllText(DataFile, "[]");
                }
                _initialized = true;
            }
        }

        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder(64);
            foreach (byte b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static List<UserModel> LoadAll()
        {
            InitializeDatabase();
            var json = File.ReadAllText(DataFile);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        private static void SaveAll(List<UserModel> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(DataFile, json);
        }

        public static bool UsernameExists(string username)
        {
            var normalized = username.Trim();
            var users = LoadAll();
            return users.Any(u => string.Equals(u.Username, normalized, StringComparison.OrdinalIgnoreCase));
        }

        public static bool RegisterUser(UserModel user)
        {
            var users = LoadAll();

            string normalized = user.Username.Trim();
            if (users.Any(u => string.Equals(u.Username, normalized, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("That username is already taken.");

            user.FirstName = user.FirstName.Trim();
            user.LastName = user.LastName.Trim();
            user.Username = normalized;
            user.PhoneNumber = user.PhoneNumber.Trim();
            user.PasswordHash = HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;

            // Simple id generation
            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
            user.Password = string.Empty; // don't store plain password

            users.Add(user);
            SaveAll(users);
            return true;
        }

        public static UserModel? AuthenticateUser(string username, string password)
        {
            var normalized = username.Trim();
            var hash = HashPassword(password);
            var users = LoadAll();
            var u = users.FirstOrDefault(x => string.Equals(x.Username, normalized, StringComparison.OrdinalIgnoreCase) && x.PasswordHash == hash);
            return u;
        }
    }
}
