using AmazonLockerService.models;
using AmazonLockerService.repository.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class OrderRepositoryInMemory : BaseRepository<Order>, IOrderRepository
    {
        private static OrderRepositoryInMemory instance;

        static OrderRepositoryInMemory() { }
        private OrderRepositoryInMemory() { }
        public static OrderRepositoryInMemory Instance { get { return instance; } }
    }
}
