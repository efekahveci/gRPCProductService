using gRPCProductService.Repository;
using gRPCProductService.Service;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseEndpoints(endpoints =>
{

    endpoints.MapGrpcService<ProductService>();


    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
    });


});

var efe = new ProductRepository().GetProducts();

foreach (var item in efe)
{
    Console.WriteLine(item);
}

app.Run();


