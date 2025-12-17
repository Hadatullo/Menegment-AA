namespace Franges2.Models;

public partial class Maintenance
{
    public int MaintenanceId { get; set; }

    public int MachineId { get; set; }

    public DateOnly MaintenanceDate { get; set; }

    public string WorkDescription { get; set; } = null!;

    public string? ProblemsDescription { get; set; }

    public int PerformerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual VendingMachine Machine { get; set; } = null!;

    public virtual User Performer { get; set; } = null!;
}