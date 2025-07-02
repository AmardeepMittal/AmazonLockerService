using AmazonLockerService.models;
using AmazonLockerService.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.controller
{
    /// <summary>
    /// Understanding: 
    /// </summary>
    public class LockerController
    {
        public readonly ILockerService _lockerService;
        public readonly OtpService _otpService;
        public readonly INotificationService _notificationService;

        public LockerController(ILockerService lockerService, OtpService otpService, INotificationService notificationService)
        {
            _lockerService = lockerService;
            _otpService = otpService;
            _notificationService = notificationService;
        }

        public bool AllocateLocker(LockerUser user, Order package, Location location) { 
            var locker = _lockerService.AllocateLocker(package, location);
            if (locker == null) {
                throw new Exception("Allocation failed");
            }
            var otp = _otpService.AssignOtp(locker);
            _notificationService.Notify(user.Contact, otp.ToString(), locker.Id.ToString());
            return true;
        }

        public bool DeallocateLocker(Locker locker) {
            return _lockerService.DeallocateLocker(locker);
        }

        

    }
}
