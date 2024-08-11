namespace salesAdmin.DTOs.Product;

public class CreateProductDto
{
    public string Name { get; set; } = "";
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public bool Active { get; set; }
}
