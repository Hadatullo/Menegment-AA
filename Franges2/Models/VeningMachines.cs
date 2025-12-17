namespace Franges2.Models;

public partial class VendingMachine
{
    public int MachineId { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string InventoryNumber { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public DateOnly ProductionDate { get; set; }

    public DateOnly CommissioningDate { get; set; }

    public DateOnly LastVerificationDate { get; set; }

    public int? VerificationIntervalMonths { get; set; }

    public int ResourceHours { get; set; }

    public DateOnly NextMaintenanceDate { get; set; }

    public int MaintenanceTimeHours { get; set; }

    public string Status { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateOnly InventoryDate { get; set; }

    public int? LastVerificationEmployeeId { get; set; }

    public int FranchiseeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Franchisee { get; set; } = null!;

    public virtual User? LastVerificationEmployee { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Sale.Payment> Payments { get; set; } = new List<Sale.Payment>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}