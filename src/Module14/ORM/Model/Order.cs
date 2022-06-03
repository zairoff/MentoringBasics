using System;

namespace ORM.Model
{
    public class Order : Entity
    {
        public string Status { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
