﻿using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetCart();
        Cart GetCart(Guid id);

        //void DeleteProduct(Product p);

        Guid AddCart(Cart c);
    }
}
