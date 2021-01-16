using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class ShoppingCartViewModel
    {
        /*public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }*/

        public Guid Id { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
