using System;
using Microsoft.AspNetCore.Http.Features;

namespace PDS.Domain.Entities
{
    public class Order: BaseEntity
    {
        public int Amount { get; set; }

        public double Price  { get; set; }

        public ProductRoute ProductRoute { get; set; }
        public long? ProductRouteId { get; set; }

        public OrderSplitted OrderSplitted { get; set; }
        public long? OrderSplittedId { get; set; }

        public DateTime TimeToAnswer { get; set; }

        public bool Response { get; set; }
    }
}

