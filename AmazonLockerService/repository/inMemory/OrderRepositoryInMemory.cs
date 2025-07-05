using AmazonLockerService.models;
using AmazonLockerService.repository.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    //Repositories has be to be singleton to avoid multiple instances of the same repository, so that DBSet is not reinitialized every time.
    public class OrderRepositoryInMemory : BaseRepository<Order>, IOrderRepository
    {
        private static OrderRepositoryInMemory instance = new OrderRepositoryInMemory();

        private OrderRepositoryInMemory() { }
        public static OrderRepositoryInMemory Instance { get { return instance; } }
    }
}
