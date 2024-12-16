
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.Map("/products/category/{category}", async(String Category,ISender sender) =>
		{
			var result = await sender.Send(new GetProductByCategoryQuery(Category));
			var response = result.Adapt<GetProductByCategoryResponse>();
			return Results.Ok(response);
		})
		.WithName("GetProductsBycategory")
		.Produces<GetProductsResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Get ProductsBycategory")
		.WithDescription("Get ProductsBycategory");
	}
}
