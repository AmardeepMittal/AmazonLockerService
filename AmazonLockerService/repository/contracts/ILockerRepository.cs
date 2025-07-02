using AmazonLockerService.Enum;
using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public interface ILockerRepository : IBaseRepository<Locker>
    {



        //IEnumerable<Slot> GetAllAvailableSlots();
        //Locker CreateLocker(string lockerId);
        //Slot CreateSlot(string slotId, Locker locker, Size size);
        //bool AllocateSlot(Package package, Slot slot);
        //bool DeallocateSlot(Slot slot);
    }
}
