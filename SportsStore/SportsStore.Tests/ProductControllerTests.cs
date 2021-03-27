using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products)
                .Returns(new List<Product>
                {
                    new Product
                    {
                        ProductId = 1,
                        Name = "P1"
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "P2"
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "P3"
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "P4"
                    },
                    new Product
                    {
                        ProductId = 5,
                        Name = "P5"
                    },
                }.AsQueryable());

            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            var result = controller.List(2) as ViewResult;

            var products = result?.ViewData.Model as ProductsListViewModel;
            Assert.NotNull(products);
            var productArray = products.Products.ToArray();
            Assert.Equal(2, productArray.Length);
            Assert.Equal("P4", productArray[0].Name);
            Assert.Equal("P5", productArray[1].Name);
        }
    }
}