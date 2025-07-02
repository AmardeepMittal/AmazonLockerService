using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Locker
    {
        public string LockerId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Slot> Slots { get; set; }

        public Locker(string id, Location location) { 
            LockerId = id;
            Location = location;
        }

        //public IEnumerable<Slot> GetSlots() { 
        //    return slots?.Where(x => x.IsAvailable());
        //}

    }
}
