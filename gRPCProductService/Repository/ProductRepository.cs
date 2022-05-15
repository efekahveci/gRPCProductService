using Bogus;
using ProductProto;
namespace gRPCProductService.Repository;


public class ProductRepository
{

    public List<ProductModel> GetProducts()
    {


        var productFaker = new Faker<ProductModel>()
            .RuleFor(x => x.ProductId, x => ++x.IndexVariable)
            .RuleFor(x => x.ProductName, x => x.Commerce.ProductName());


        return productFaker.Generate(10).ToList();

    }


}
