using GraphQL.Types;
using Graphql_.Net.Models;

namespace Graphql_.Net.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price);
        }
    }
}
