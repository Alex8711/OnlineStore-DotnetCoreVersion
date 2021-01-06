using System;
using OnlineStore.Models;

namespace OnlineStore.Dtos
{
    public class LineItemDto
    {

        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid? ShoppingCartId { get; set; }
        //public Guid? OrderId { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPercentage { get; set; }
    }
}