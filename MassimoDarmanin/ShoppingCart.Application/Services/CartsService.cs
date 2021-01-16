using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartsService : ICartsService
    {
        private ICartRepository _cartsRepo;
        public void AddCart(ShoppingCartViewModel cart)
        {
            Cart newCart = new Cart()
            {
                Count = cart.Count,
                DateCreated = cart.DateCreated,
                ProductId = cart.Product.Id
            };
            _cartsRepo.AddCart(newCart);
        }

        public ShoppingCartViewModel GetCart(Guid id)
        {
            var myCart = _cartsRepo.GetCart(id);

            ShoppingCartViewModel myModel = new ShoppingCartViewModel();
            myModel.Count = myCart.Count;
            myModel.DateCreated = myCart.DateCreated;
            myModel.Product = new ProductViewModel()
            {
                Id = myCart.Product.Id,
                Name = myCart.Product.Name,
                Price = myCart.Product.Price,
                //Stock = myCart.Product.Stock

            };
            return myModel;
        }

        public IQueryable<ShoppingCartViewModel> GetCarts()
        {
            /*var list = from p in _cartsRepo.GetCarts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Description = p.Description,
                           Name = p.Name,
                           Price = p.Price,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name },
                           ImageUrl = p.ImageUrl*/
                       };
            return list;
        }

        public IQueryable<ShoppingCartViewModel> GetCarts(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
