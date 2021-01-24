using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetCart();
        Cart GetCart(string email, Guid productId);

        //void DeleteProduct(Product p);

        Guid AddToCart(Cart c);

        void UpdateCart(Cart cart);
        object GetCart(Guid id);
    }
}
