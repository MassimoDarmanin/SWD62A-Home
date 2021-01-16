using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [DefaultValue(false)]
        public bool Disable { get; set; } //to refresh the db,you must always run Add-Migration & Update-Database

    }
}
