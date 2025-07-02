using AmazonLockerService.models;
using AmazonLockerService.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.controller
{
    public class ReturnController
    {
        public readonly ILockerService _lockerService;
        public readonly OtpService _otpService;
        public readonly INotificationService _notificationService;

        public ReturnController(ILockerService lockerService, OtpService otpService, INotificationService notificationService)
        {
            _lockerService = lockerService;
            _otpService = otpService;
            _notificationService = notificationService;
        }

        public bool AllocatePickUp(Locker locker, Location location)
        {
            var locker = _lockerService.AllocateLocker(package, location);
            if (locker == null)
            {
                throw new Exception("Allocation failed");
            }
            var otp = _otpService.AssignOtp(locker);
            _notificationService.Notify(user.Contact, otp.ToString(), locker.Id.ToString());
            return true;
        }

        public bool DeallocateLocker(Locker locker)
        {
            return _lockerService.DeallocateLocker(locker);
        }
    }
}
