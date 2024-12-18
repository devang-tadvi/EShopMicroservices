
namespace Basket.API.Basket.DeleteBasket
{
	public record DeleteBasketRequest(string UserName);
	public record DeletBasketResponse(bool IsSuccess);
	public class DeleteBasketEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapDelete("/basket/{username}", async (string userName, ISender sender) =>
			{
				var result = await sender.Send(new DeleteBasketCommand(userName));

				var response = result.Adapt<DeletBasketResponse>();

				return Results.Ok(response);
			}).WithName("Delete basket")
			.Produces<DeletBasketResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("Delete basket")
			.WithDescription("Delete basket");
		}
	}
}