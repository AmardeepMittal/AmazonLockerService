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
        IOtpService _otpService;
        ILockerRepository lockerRepository = LockerRepositoryInMemory.Instance;
        IPackageRepository _packageRepository = PackageRepositoryInMemory.Instance;
        ISlotFilterStrategy _filterStrategy;
        public SlotServiceImpl(IOtpService otpService, ISlotFilterStrategy filterStrategy) {
            _otpService = otpService;
            _filterStrategy = filterStrategy;
        }

        public Slot addPackageToSlot(string lockerId, Package package)
        {
            var availableSlots = _slotRepository
                                    .getAvailableSlotsByLockerId(lockerId);
                                    

            if (!availableSlots.Any())
            {
                throw new NoSlotAvailableException();
            }
            var locker = lockerRepository.FindById(lockerId);
            var code = _otpService.GenerateOtp();
            package.Code = code;
            var filteredSlots = _filterStrategy.FilterSlots(availableSlots, package.Size);
            var slot = filteredSlots.FirstOrDefault();
            if (slot == null)
            {
                throw new NoSlotAvailableException();
            }

            slot.Package = package;
            slot.AllocationDate = DateTime.Now;
            slot.Status = Enum.SlotStatus.Occupied;
            slot.Locker = locker;
            _slotRepository.Update(slot.Id, slot);
            return slot;
        }

        public IEnumerable<Slot> getAvailableSlots()
        {
            return _slotRepository.getAvailableSlots();
        }

        public void pickUpPackage(string slotId, string packageId, int code)
        {
            var slot = _slotRepository.FindById(slotId);
            if (slot == null) throw new Exception("Invalid slot id");
            var package = slot.Package;
            if(package == null || package.Id != packageId) throw new Exception("Invalid package id");
            if(!_otpService.ValidateOtp(code) || package.Code != code) throw new Exception("Invalid otp code");

            _packageRepository.Update(packageId, null);

            slot.Package = null;
            slot.AllocationDate = DateTime.MinValue;
            slot.Status = Enum.SlotStatus.Available;
            _slotRepository.Update(slotId, slot);

        }
    }
}
