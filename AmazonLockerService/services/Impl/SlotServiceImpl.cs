using AmazonLockerService.models;
using AmazonLockerService.repository;
using AmazonLockerService.repository.inMemory;
using AmazonLockerService.services.contracts;
using AmazonLockerService.strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services.Impl
{
    public class SlotServiceImpl : ISlotService
    {
        ISlotRepository _slotRepository = SlotRepositoryInMemory.Instance;
        ISlotFilterStrategy _filterStrategy;

        public SlotServiceImpl(ISlotFilterStrategy filterStrategy) {
            _filterStrategy = filterStrategy;
        }

        public Slot addPackageToSlot(int lockerId, Package package)
        {
            var availableSlots = _slotRepository
                                    .getAvailableSlotsByLockerId(lockerId);
                                    

            if (!availableSlots.Any())
            {
                throw new NoSlotAvailableException();
            }
            var filteredSlots = _filterStrategy.FilterSlots(availableSlots, package.Size);
            var slot = filteredSlots.FirstOrDefault();
            if (slot == null)
            {
                throw new NoSlotAvailableException();
            }

            slot.AllocationDate = DateTime.Now;
            slot.Status = Enum.SlotStatus.Occupied;
            _slotRepository.Update(slot.Id, slot);
            return slot;
        }

        public void RemovePackageFromSlot(int slotId)
        {
            var slot = _slotRepository.FindById(slotId);
            if (slot == null) throw new Exception("Invalid slot id");
            slot.AllocationDate = DateTime.MinValue;
            slot.Status = Enum.SlotStatus.Available;
            _slotRepository.Update(slotId, slot);
        }
    }
}
