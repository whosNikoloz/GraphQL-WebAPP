using Graphql_.Net.Data;
using Graphql_.Net.Dto;
using Graphql_.Net.Models;
using Graphql_.Net.Services;

namespace Graphql_.Net.GraphQL
{
    public class Mutation
    {
        public string SayHello(string name) => $"Hello, {name}!";

        private readonly ProductService _productService;

        public Mutation(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> CreateProductAsync(ProductDto input)
        {
             return await _productService.CreateProductAsync(input);
        }
    }
}
