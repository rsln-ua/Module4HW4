namespace Module4HW4.Data.Entities;

public class Payment
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public bool Allowed { get; set; }
    public List<Order> Orders { get; set; } = null!;
}