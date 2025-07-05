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
        IOtpService _otpService;
        public Order CreateOrder(IEnumerable<string> items, User user, DateTime orderDateTime)
        {
            var nearByLocker = _lockerService.FindNearByLocker(user.Location);
            var order = new Order();
            order.Items = items;    
            order.User = user;
            order.OrderDateTime = orderDateTime;
            order.Locker = nearByLocker;
            _orderRepository.Add(order);
            return order;
        }

        public void DeliverOrderToLocker(int orderId, DeliveryPerson person) { 
            var order = _orderRepository.FindById(orderId);
            var package = new Package();
            package.Order = order;
            package.DeliveryPerson = person;
            package.Size = Size.Medium; // Assuming a default size, this can be changed based on items.
            package.Items = order.Items;
            
            var code = _otpService.GenerateOtp();
            package.Code = code;
            var slot = _slotService.addPackageToSlot(order.Locker.Id, package);
            package.Slot = slot;
            _packageRepository.Add(package);
            _notificationService.Notify(order.User, package.Code, slot.Id, order.Locker.Location);
        }

        public void PickUpOrder(int orderId, int code)
        {
            var order = _orderRepository.FindById(orderId);
            Package package = _packageRepository.FindOrderById(orderId);
            if(code != package.Code)
            {
                throw new UnauthorizedAccessException("Invalid code provided for order pickup.");
            }
            _slotService.RemovePackageFromSlot(package.Slot.Id);
        }
    }
}
