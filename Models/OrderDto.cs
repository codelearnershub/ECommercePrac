using ECommerce.Entities;
using ECommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public List<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }

    public class CreateOrderRequestModel
    {
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public List<int> Brands { get; set; } = new List<int>();

    }
}
