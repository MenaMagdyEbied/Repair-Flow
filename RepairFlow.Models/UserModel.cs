using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairFlow.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Plain-text password only used temporarily in UI logic
        [NotMapped]
        public string Password { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
