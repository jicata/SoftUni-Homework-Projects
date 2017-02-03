namespace Products.Models
{
    using System;
    using Enums;

    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public virtual Status Status { get; set; }
    }
}
