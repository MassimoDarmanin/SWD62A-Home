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
        public CartsService(ICartsService cartRepo)
        {
            //_cartsRepo = cartRepo;
        }
        public void AddToCart(string email, Guid productId, int count)
        {
            //Cart newCart = new Cart()
            //{
            //    Count = cart.Count,
            //    DateCreated = cart.DateCreated,
            //    ProductId = cart.Product.Id
            //};
            //_cartsRepo.AddCart(newCart);
            Cart cart = _cartsRepo.GetCart(email, productId);
            if (cart == null)
            {
                _cartsRepo.AddToCart(new Cart()
                {
                    Email = email,
                    ProductId = productId,
                    Count = count
                });
            }
            else
            {
                UpdateQtyInCart(email, productId, count);
            }
        }

        /*public ShoppingCartViewModel GetCart(string email, Guid id)
        {
            var myCart = _cartsRepo.GetCart(email,id);

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
        }*/

        public IQueryable<ShoppingCartViewModel> GetCart(Guid id)
        {
            var list = from p in _cartsRepo.GetCart().Where(x => x.Product.Id == id)
                       select new ShoppingCartViewModel()
                       {
                           Id = p.Id,
                           Count = p.Count,
                           DateCreated = p.DateCreated,
                           Product = new ProductViewModel() { Id = p.Product.Id, Name = p.Product.Name, Price = p.Product.Price }
                       };
            return list;
        }

        public void UpdateQtyInCart(string email, Guid productId, int count)
        {
            Cart originalCart = null;
            originalCart.Count = count;

            _cartsRepo.UpdateCart(originalCart);//orignial cart has been edited
        }

        /*ShoppingCartViewModel ICartsService.GetCart(Guid id)
        {
            var myCart = _cartsRepo.GetCart();

            ShoppingCartViewModel myModel = new ShoppingCartViewModel();
            //myModel.Id = myCart.i
            //myModel.Count = myCart.Count;
            //myModel.DateCreated = myCart.DateCreated;
            //myModel.Email = myCart.Email;
            myModel.Product = new ProductViewModel()
            {
                Id = myModel.Product.Id,
                Name = myModel.Product.Name,
                Price = myModel.Product.Price,
                //Stock = myModel.Product.Stock
            };
            return myModel;
        }*/
    }
}
