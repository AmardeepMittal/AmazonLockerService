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
        Order CreateOrder(IEnumerable<string> items, User user, DateTime orderDateTime);
        void DeliverOrderToLocker(int orderId, DeliveryPerson person);
        void PickUpOrder(int orderId, int code);
    }
}
