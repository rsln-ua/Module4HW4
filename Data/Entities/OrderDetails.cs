namespace Module4HW4.Data.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}