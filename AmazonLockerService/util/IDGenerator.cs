using AmazonLockerService.repository.inMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AmazonLockerService.util
{
    public class IDGenerator
    {
        private int sequencer = 1;
        public IDGenerator()
        {
            // Private constructor to prevent instantiation
        }

        public int GenerateId()
        {
            // Generate a unique ID using a sequencer.
            Interlocked.Increment(ref sequencer);
            return sequencer;
        }
    }
}
