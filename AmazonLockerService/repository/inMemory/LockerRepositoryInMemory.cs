using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class LockerRepositoryInMemory : BaseRepository<Locker>, ILockerRepository
    {
        private static LockerRepositoryInMemory instance;

        static LockerRepositoryInMemory() { }
        private LockerRepositoryInMemory() { }
        public static LockerRepositoryInMemory Instance { get { return instance; } }

    }
}
