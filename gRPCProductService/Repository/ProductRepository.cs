using ProductProto;
using Bogus;
namespace gRPCProductService.Repository;


public class ProductRepository
{
    public ProductRepository()
    {

    }

    public List<ProductModel> products = new List<ProductModel>();

    public List<ProductModel> GetProducts()
    {
    


        var productFaker = new Faker<ProductModel>()
            .RuleFor(x => x.ProductId, x => ++ x.IndexVariable)
            .RuleFor(x => x.ProductName, x => x.Commerce.ProductName());

      var test =  productFaker.Generate(5);

        return test;

    }


}
