using AmazonLockerService.Enum;
using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.strategy
{
    public class SlotFilterStrategy : ISlotFilterStrategy
    {
        public IEnumerable<Slot> FilterSlots(IEnumerable<Slot> slots, Size size)
        {
            if(slots == null || !slots.Any()) return null;
            return slots.Where(x => x.CanAccomodate(size));
        }
    }
}
