namespace ShoppingCartPractice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Carts
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public DateTime PublishDate { get; set; }

        public int DefaultImageId { get; set; }

        public int Quantity { get; set; }

        
    }
}
