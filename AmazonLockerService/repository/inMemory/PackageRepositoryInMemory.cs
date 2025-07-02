using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class PackageRepositoryInMemory : BaseRepository<Package>, IPackageRepository
    {
        private static PackageRepositoryInMemory instance;

        static PackageRepositoryInMemory() { }
        private PackageRepositoryInMemory() { }
        public static PackageRepositoryInMemory Instance { get { return instance; } }
    }
}
