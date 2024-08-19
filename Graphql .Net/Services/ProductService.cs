using Graphql_.Net.Data;
using Graphql_.Net.Dto;
using Graphql_.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql_.Net.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products.AsQueryable();
        }
        public Task<Product> GetProductByIdAsync(int id)
        {
            return _context.Products.FindAsync(id).AsTask();
        }

        public async Task<Product> CreateProductAsync(ProductDto input)
        {
            // Ensure this is within the request scope
            var product = new Product
            {
                Name = input.Name,
                Price = input.Price,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
