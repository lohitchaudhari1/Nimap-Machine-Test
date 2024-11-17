namespace ProductCategoryMVC.Models;

public class ProductPaginationViewModel
{
    public List<Product> Products { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}