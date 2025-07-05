using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    //Repositories has be to be singleton to avoid multiple instances of the same repository, so that DBSet is not reinitialized every time.

    public class SlotRepositoryInMemory : BaseRepository<Slot>, ISlotRepository
    {
        private static SlotRepositoryInMemory instance;

        private SlotRepositoryInMemory() { }
        public static SlotRepositoryInMemory Instance { get { return instance; } }

        public IEnumerable<Slot> getAvailableSlots()
        {
            return DbSet
                    .Values
                    .AsEnumerable<Slot>()
                    .Where(x => x.Status == Enum.SlotStatus.Available);
        }

        public IEnumerable<Slot> getAvailableSlotsByLockerId(int lockerId)
        {
            return DbSet
                    .Values
                    .AsEnumerable<Slot>()
                    .Where(x => x.Locker.Id == lockerId && x.Status == Enum.SlotStatus.Available);
        }
    }
}
