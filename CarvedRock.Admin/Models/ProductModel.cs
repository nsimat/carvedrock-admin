using Microsoft.AspNetCore.Authentication;

namespace CarvedRock.Admin.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
} 