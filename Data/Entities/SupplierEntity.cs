namespace Module4HW4.Data.Entities;

public class SupplierEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string ContactFName { get; set; } = null!;
    public string ContactLName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public List<ProductEntity> Products { get; set; } = null!;
}