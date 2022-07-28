using System;

namespace ADO.NET.Model
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
