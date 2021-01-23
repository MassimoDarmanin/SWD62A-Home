using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;


namespace ShoppingCart.Data.Repositories
{
    public class CartsRepository : ICartRepository
    {
        ShoppingCartDbContext _context;
        public CartsRepository(ShoppingCartDbContext context)
        {
            _context = context;

        }

        public Guid AddToCart(Cart c)
        {
            //ShoppingCartDbContext context = new ShoppingCartDbContext();
            _context.Carts.Add(c);
            _context.SaveChanges();
            return c.Id;
        }

        public IQueryable<Cart> GetCart()
        {
            return _context.Carts;
        }

        public Cart GetCart(string email, Guid productId)
        {
            return _context.Carts.SingleOrDefault(x => x.Id == productId);
        }

        public void UpdateCart(Cart cart)
        {
            _context.Update(cart);
            _context.SaveChanges();
        }
    }
}
