namespace RepairFlow.Models
{
    public class AppUser
    {
        public bool IsActive;

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;   
        public string Username { get; set; } = string.Empty;   
        public string PasswordHash { get; set; } = string.Empty;   
        public UserRole Role { get; set; } = UserRole.Admin;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string FullName  => $"{FirstName} {LastName}";
    }
    public enum UserRole
    {
        Admin = 1,
    }
}
