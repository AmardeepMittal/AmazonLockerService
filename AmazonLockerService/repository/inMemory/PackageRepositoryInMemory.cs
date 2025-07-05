using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    //Repositories has be to be singleton to avoid multiple instances of the same repository, so that DBSet is not reinitialized every time.

    public class PackageRepositoryInMemory : BaseRepository<Package>, IPackageRepository
    {
        private static PackageRepositoryInMemory instance;

        private PackageRepositoryInMemory() { }
        public static PackageRepositoryInMemory Instance { get { return instance; } }

        public Package FindOrderById(int orderId)
        {
            return DbSet
                .Values
                .AsEnumerable<Package>()
                .FirstOrDefault(p => p.Order.Id == orderId);
        }
    }
}
