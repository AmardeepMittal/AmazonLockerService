using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.strategy
{
    public class SlotAssignmentStrategy : ISlotAssignmentStrategy
    {
        public Slot AssignSlot(IEnumerable<Slot> slots) {
            if (slots == null || !slots.Any())
                return null;
            return slots.First();
        }
    }
}
