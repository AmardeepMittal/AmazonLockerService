using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Locker : BaseEntity
    {
        public Location Location { get; set; }
        public IEnumerable<Slot> Slots { get; set; }

        public Locker() { }

        public Locker(int id, Location location) { 
            Id = id;
            Location = location;
        }

        //public IEnumerable<Slot> GetSlots() { 
        //    return slots?.Where(x => x.IsAvailable());
        //}

    }
}
