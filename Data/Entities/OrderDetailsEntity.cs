namespace Module4HW4.Data.Entities;

public class OrderDetailsEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity ProductEntity { get; set; } = null!;
    public int OrderId { get; set; }
    public OrderEntity OrderEntity { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}