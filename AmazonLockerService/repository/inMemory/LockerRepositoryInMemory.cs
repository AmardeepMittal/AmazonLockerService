using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    //Repositories has be to be singleton to avoid multiple instances of the same repository, so that DBSet is not reinitialized every time.
    public class LockerRepositoryInMemory : BaseRepository<Locker>, ILockerRepository
    {
        private static LockerRepositoryInMemory instance = new LockerRepositoryInMemory();
        private LockerRepositoryInMemory() { }
        public static LockerRepositoryInMemory Instance => instance;
    }
}
