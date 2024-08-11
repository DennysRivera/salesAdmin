namespace salesAdmin.DTOs.Sale;

public class CreateSaleDto
{
    public string Client { get; set; } = "";
    public string? Description { get; set; } = "";
    public string Contact { get; set; } = "";
    public double TotalPrice { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsPaid { get; set; }
}
