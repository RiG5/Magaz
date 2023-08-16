using System;

namespace MyApp.Web.Api.Bussiness.Entities
{
    public class OrderItem
    {
        public Int32 IdOrder { get; set; }
        public Int32 IdProduct { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Amount { get; set; }
        public Int32 Price { get; set; }
        public long Id { get; set; }
    }
}