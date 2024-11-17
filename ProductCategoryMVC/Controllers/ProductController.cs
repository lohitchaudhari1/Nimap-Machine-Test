using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategoryMVC.Data;
using ProductCategoryMVC.Models;
using System.Linq;


namespace ProductsAndCategories.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 10;  // Number of products per page

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Product/Index
        public IActionResult Index(int page = 1)
        {
            var totalProducts = _context.Products.Count();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)PageSize);

            // Fetch products for the current page
            var products = _context.Products
                .Include(p => p.Category)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Create the view model with pagination data
            var viewModel = new ProductPaginationViewModel
            {
                Products = products,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }
    }
}