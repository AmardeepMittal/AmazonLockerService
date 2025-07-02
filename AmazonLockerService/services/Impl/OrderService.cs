using AmazonLockerService.Enum;
using AmazonLockerService.models;
using AmazonLockerService.repository;
using AmazonLockerService.repository.contracts;
using AmazonLockerService.repository.inMemory;
using AmazonLockerService.services.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services.Impl
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository = OrderRepositoryInMemory.Instance;
        IPackageRepository  _packageRepository = PackageRepositoryInMemory.Instance;
        ILockerService _lockerService;
        ISlotService _slotService;
        INotificationService _notificationService;
        public Order CreateOrder(string id, IEnumerable<string> items, User user, DateTime orderDateTime)
        {
            var order = new Order(id, user, orderDateTime);
            _orderRepository.Add(id, order);
            return order;
        }

        public void DeliverOrder(string id, DeliveryPerson person, Size size) { 
            var order = _orderRepository.FindById(id);
            var package = new Package(Guid.NewGuid().ToString(), size, order, person);
            var locker = _lockerService.FindNearByLocker(order.User.Location);
            var slot = _slotService.addPackageToSlot(locker.LockerId, package);
            _notificationService.Notify(order.User, slot.Package.Code, slot.Id, locker.Location);

        }
    }
}
