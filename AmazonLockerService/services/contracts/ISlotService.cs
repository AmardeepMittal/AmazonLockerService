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
        IEnumerable<Slot> getAvailableSlots();
        Slot addPackageToSlot(string lockerId, Package package);
        void pickUpPackage(string slotId, string packageId, int code);
    }
}
