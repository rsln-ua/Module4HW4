namespace Module4HW4.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Picture { get; set; } = null!;
    public bool Active { get; set; }
    public List<Product> Products { get; set; } = null!;
}