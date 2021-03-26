using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class FakeRepository : IProductRepository
    {
        public IQueryable<Product> Products =>
            new List<Product>
            {
                new() { Name = "Football", Price = 25 },
                new() { Name = "Surf Board", Price = 179 },
                new() { Name = "Running shoes", Price = 95 },
            }.AsQueryable();
    }
}