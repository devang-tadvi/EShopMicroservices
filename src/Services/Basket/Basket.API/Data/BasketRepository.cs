
using Basket.API.Exceptions;
using Marten;

namespace Basket.API.Data;

public class BasketRepository(IDocumentSession sessoin) : IBasketRepository
{
	public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
	{
		sessoin.Delete<ShoppingCart>(userName);
		await sessoin.SaveChangesAsync(cancellationToken);
		return true;
	}

	public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
	{
		
		var basket = await sessoin.LoadAsync<ShoppingCart>(userName, cancellationToken);
		return basket is null ? throw new BasketNotFoundException(userName) : basket;
	}

	public async Task<ShoppingCart> StoreCart(ShoppingCart basket, CancellationToken cancellationToken)
	{
		sessoin.Store(basket);
		await sessoin.SaveChangesAsync(cancellationToken);
		return basket;
	}
}
