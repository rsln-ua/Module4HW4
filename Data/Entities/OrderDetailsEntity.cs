namespace Module4HW4.Data.Entities;

public class OrderDetailsEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}