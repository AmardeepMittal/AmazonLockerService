using AmazonLockerService.Enum;
using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services.contracts
{
    public interface IOrderService
    {
        Order CreateOrder(string id, IEnumerable<string> items, User user, DateTime orderDateTime);
        void DeliverOrder(string id, DeliveryPerson person, Size size);
    }
}
