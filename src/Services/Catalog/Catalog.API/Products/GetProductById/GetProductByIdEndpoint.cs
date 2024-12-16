
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.Map("/products/{id}", async(Guid id,ISender sender) =>
		{
			var result = await sender.Send(new GetProductByIdQuery(id));
			var response = result.Adapt<GetProductByIdResponse>();
			return Results.Ok(response);
		})
		.WithName("GetProductsById")
		.Produces<GetProductsResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Get ProductsById")
		.WithDescription("Get ProductsById");
	}
}
