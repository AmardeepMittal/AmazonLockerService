using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.strategy
{
    public interface ISlotAssignmentStrategy
    {
        Slot AssignSlot(IEnumerable<Slot> slots); 
    }
}
