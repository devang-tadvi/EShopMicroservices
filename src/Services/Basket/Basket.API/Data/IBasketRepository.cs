﻿namespace Basket.API.Data;

public interface IBasketRepository
{
	Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
	Task<ShoppingCart> StoreCart(ShoppingCart basket, CancellationToken cancellationToken);
	Task<bool> DeleteBasket(string userName,CancellationToken cancellationToken = default);
}
