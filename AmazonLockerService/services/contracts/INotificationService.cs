using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services
{
    public interface INotificationService
    {
        bool Notify(User user, int otp, string slotId, Location location);
    }
}
