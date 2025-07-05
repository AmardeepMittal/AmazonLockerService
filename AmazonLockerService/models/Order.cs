using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Order: BaseEntity
    {
        //public Package Package { get; set; }
        public IEnumerable<string> Items { get; set; }
        public User User { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Locker Locker { get; set; }

        public Order() {}

        public Order(int id, User user, DateTime orderDateTime)
        {
            Id = id;
            User = user;
            OrderDateTime = orderDateTime;
        }


    }
}
