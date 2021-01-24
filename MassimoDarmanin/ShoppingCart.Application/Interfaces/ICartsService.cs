using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartsService
    {
        //IQueryable<ShoppingCartViewModel> GetCarts();

        //IQueryable<ShoppingCartViewModel> GetCarts(string keyword);

        //ShoppingCartViewModel GetCart(Guid id);

        void AddToCart(string email, Guid productId, int qty);

        void UpdateQtyInCart(string email, Guid productId, int qty);

    }
}
