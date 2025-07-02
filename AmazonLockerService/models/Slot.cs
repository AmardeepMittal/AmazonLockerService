using AmazonLockerService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Slot
    {
        public string Id { get; set; }
        public Size Size { get; set; }
        public Locker Locker { get; set; }
        public SlotStatus Status { get; set; }
        public DateTime? AllocationDate { get; set; }
        public Package Package { get; set; }


        public Slot(string id, Size size, Locker locker) { 
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
