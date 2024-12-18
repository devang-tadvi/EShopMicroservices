


using MediatR;

namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string userName);

public record GetBasketResponse(ShoppingCart ShoppingCart);

public class GetBasketEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/basket/{username}", async (string userName, ISender sender) =>
		{
			var result = await sender.Send(new GetBasketQuery(userName));

			var response = result.Adapt<GetBasketResponse>();
			return Results.Ok(response);
		}).WithName("GetBasketResult")
		.Produces<GetBasketResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("GetBasket")
		.WithDescription("GetBasket"); ;
	}
}
