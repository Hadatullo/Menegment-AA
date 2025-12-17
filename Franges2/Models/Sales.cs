namespace Franges2.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int MachineId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal SaleAmount { get; set; }

    public DateTime SaleDatetime { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User.VendingMachine Machine { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public class Payment
    {
    }

    public virtual Product Product { get; set; } = null!;
}