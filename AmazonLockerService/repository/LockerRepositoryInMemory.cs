using AmazonLockerService.Enum;
using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public class LockerRepositoryInMemory : ILockerRepository
    {
        IList<Locker> _allLockers = new List<Locker>();



        //public bool AllocateLocker(Locker locker, Package package)
        //{
        //    if (_lockerAllocations.ContainsKey(locker.Id))
        //    {
        //        throw new Exception("Locker already in use");
        //    }
        //    _lockerAllocations[locker.Id] = package;
        //    return true;
        //}

        //public bool DeallocateLocker( Locker locker)
        //{
        //    if (!_lockerAllocations.ContainsKey(locker.Id))
        //    {
        //        throw new Exception("Locker is not allocated to any package");
        //    }
        //    _lockerAllocations.Remove(locker.Id);
        //    return true;
        //}

        //public bool CreateLocker(Locker locker) { 
        //    _allLockers.Add(locker.Id, locker);
        //    return true;
        //}

        public LockerRepositoryInMemory(IList<Locker> lockers) {
            _allLockers = lockers;
        }

        public IEnumerable<Slot> GetAllAvailableSlots()
        {
            List<Slot> allSlots = new List<Slot>();
            foreach (var locker in _allLockers) {
                allSlots.AddRange(locker.GetSlots());
            }
            return allSlots;
        }

        public Locker CreateLocker(string lockerId, IEnumerable<Slot> slots)
        {
            var locker = new Locker(lockerId);
            _allLockers.Add(locker);
            return locker;
        }

        public Slot CreateSlot(string slotId, Locker locker, Size size) {
            var slot = new Slot(Guid.NewGuid().ToString(), size, locker);
            locker.Equals(slot);
            return slot;
        }

        public bool AllocateSlot(Package package, Slot slot)
        {
            slot.AllocatePackage(package);
            return true;
        }

        public bool DeallocateSlot(Slot slot)
        {
            return slot.RemovePackage();
        }
    }
}
