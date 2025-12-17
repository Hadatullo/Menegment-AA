namespace Franges2.Models;

public abstract partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();

    public class UserSession
    {
    }

    public virtual ICollection<VendingMachine> VendingMachineFranchisees { get; set; } = new List<VendingMachine>();

    public class VendingMachine
    {
    }

    public virtual ICollection<VendingMachine> VendingMachineLastVerificationEmployees { get; set; } = new List<VendingMachine>();
}