using AmazonLockerService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Slot: BaseEntity
    {
        public Size Size { get; set; }
        public Locker Locker { get; set; }
        public SlotStatus Status { get; set; }
        public DateTime? AllocationDate { get; set; }


        public Slot(int id, Size size, Locker locker) { 
            Id = id;
            Size = size;
            Locker = locker;
        }

        public bool CanAccomodate(Size size)
        {
            return this.Size == size;
        }
    }
}
