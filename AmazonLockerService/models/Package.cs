using AmazonLockerService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Package: BaseEntity
    {
        public Order Order { get; set; }
        public int Code { get; set; }
        public Size Size { get; set; }
        public IEnumerable<string> Items { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public Slot Slot { get; internal set; }

        public Package() { }
        public Package(Size size, Order order, DeliveryPerson person)
        {
            Order = order;
            Size = size;
            DeliveryPerson = person;
        }
    }
}
