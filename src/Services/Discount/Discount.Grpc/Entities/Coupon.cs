using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Entities
{
    public class Coupon
    {

        public int Id { get; set; }

        public string ProductName { get; set; } = "No Discount";

        public string Description { get; set; } = "No Discount Description";

        public int Amount { get; set; } = 0;
    }
}