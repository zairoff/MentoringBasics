using System;
using System.Collections.Generic;

namespace ORM.Model
{
    public class Order : Entity
    {
        public string Status { get; set; }

        public ICollection<Product> Products { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
