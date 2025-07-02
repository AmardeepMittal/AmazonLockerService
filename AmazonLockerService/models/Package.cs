using AmazonLockerService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Package
    {
        public string Id { get; set; }
        public Order Order { get; set; }
        public int Code { get; set; }
        public Size Size { get; set; }
        public IEnumerable<string> Items { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }


        public Package(string id, Size size, Order order, DeliveryPerson person)
        {
            Id = id;
            Order = order;
            Size = size;
            DeliveryPerson = person;
        }
    }
}
