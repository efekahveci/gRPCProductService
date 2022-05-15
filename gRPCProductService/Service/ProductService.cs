using Grpc.Core;
using gRPCProductService.Repository;
using ProductProto;

namespace gRPCProductService.Service
{
    public class ProductService : Product.ProductBase
    {

        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override Task<ProductResponse> GetAllProducts(GetAllRequest request, ServerCallContext context)
        {
            ProductResponse response = new ProductResponse();

            _productRepository.GetProducts().ForEach(x => response.Product.Add(x));

            return Task.FromResult(response);

        }

        public override Task<ProductModel> GetProduct(GetProductsRequest request, ServerCallContext context)
        {
            ProductModel model = new ProductModel();

            model = _productRepository.GetProducts().FirstOrDefault(x => x.ProductId == request.ProductId);

            if (model is not null)
                return Task.FromResult(model);
            else
                throw new RpcException(new Status(StatusCode.NotFound, "Aradığınız ID ile eşleşen ürün bulunmamaktadır."));



        }

        public override async Task SearchProducts(SearchRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
        {
            var result = _productRepository.GetProducts();

            foreach (var item in result)
            {
                if (item.ProductName.Contains(request.ProductName.ToLower()))
                {
                    await responseStream.WriteAsync(item);
                }

            }


        }
    }
}
