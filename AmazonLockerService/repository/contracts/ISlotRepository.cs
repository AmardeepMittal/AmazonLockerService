using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public interface ISlotRepository : IBaseRepository<Slot>
    {
        IEnumerable<Slot> getAvailableSlots();
        IEnumerable<Slot> getAvailableSlotsByLockerId(int lockerId);
    }
}
