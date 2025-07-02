using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class SlotRepositoryInMemory : BaseRepository<Slot>, ISlotRepository
    {
        private static SlotRepositoryInMemory instance;

        static SlotRepositoryInMemory() { }
        private SlotRepositoryInMemory() { }
        public static SlotRepositoryInMemory Instance { get { return instance; } }

        public IEnumerable<Slot> getAvailableSlots()
        {
            return DbSet
                    .Values
                    .AsEnumerable<Slot>()
                    .Where(x => x.Status == Enum.SlotStatus.Available);
        }

        public IEnumerable<Slot> getAvailableSlotsByLockerId(string lockerId)
        {
            return DbSet
                    .Values
                    .AsEnumerable<Slot>()
                    .Where(x => x.Locker.LockerId == lockerId && x.Status == Enum.SlotStatus.Available);
        }
    }
}
