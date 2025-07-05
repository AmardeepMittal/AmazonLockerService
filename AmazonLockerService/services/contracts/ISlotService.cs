using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services.contracts
{
    public interface ISlotService
    {
        Slot addPackageToSlot(int lockerId, Package package);
        void RemovePackageFromSlot(int slotId);
    }
}
