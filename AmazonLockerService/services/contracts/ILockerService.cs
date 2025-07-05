using AmazonLockerService.Enum;
using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services
{
    public interface ILockerService
    {
        Locker FindNearByLocker(Location location);
        Locker AddLocker(int lockerId, IEnumerable<Slot> slots, Location location);
    }
}
