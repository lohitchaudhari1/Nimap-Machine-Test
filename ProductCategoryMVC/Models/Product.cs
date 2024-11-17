namespace ProductCategoryMVC.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    
    // Foreign Key for Category
    public int CategoryId { get; set; }

    // Navigation Property
    public Category Category { get; set; }
}