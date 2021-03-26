using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public int PageSize = 4;
        
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        // GET
        public IActionResult List(int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = _productRepository.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize).ToArray(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    TotalItems = _productRepository.Products.Count(),
                    ItemsPerPage = PageSize
                }
            });
        }
    }
}