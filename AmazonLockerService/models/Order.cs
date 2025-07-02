using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Order
    {
        public string Id { get; set; }
        public Package Package { get; set; }
        public User User { get; set; }
        public DateTime OrderDateTime { get; set; }

        public Order(string id, User user, DateTime orderDateTime)
        {
            Id = id;
            User = user;
            OrderDateTime = orderDateTime;
        }
    }
}
