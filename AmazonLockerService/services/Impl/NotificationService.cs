using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services
{
    public class NotificationService : INotificationService
    {
        public bool Notify(User user, int otp, string slotId, Location location)
        {
            // Third party will send a notification to user for the locker allocation.
            Console.WriteLine($"Locker # {slotId} has been allocated to you at location {location} with otp code: {otp}");
            return true;
        }
    }
}
