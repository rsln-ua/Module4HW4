namespace Module4HW4.Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity CustomerEntity { get; set; } = null!;
    public int PaymentId { get; set; }
    public PaymentEntity PaymentEntity { get; set; } = null!;
    public int ShipperId { get; set; }
    public ShipperEntity ShipperEntity { get; set; } = null!;
    public int? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public List<OrderDetailsEntity> OrderDetails { get; set; } = null!;
}