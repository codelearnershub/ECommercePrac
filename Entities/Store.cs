using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class Store : BaseEntity
    {
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<StoreBrand> StoreBrands { get; set; } = new List<StoreBrand>();
    }
}
