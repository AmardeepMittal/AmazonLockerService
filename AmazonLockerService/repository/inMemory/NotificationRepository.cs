using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class NotificationRepositoryInMemory : BaseRepository<Notification>, INotificationRepository
    {
        private static NotificationRepositoryInMemory instance;

        static NotificationRepositoryInMemory() { }
        private NotificationRepositoryInMemory() { }
        public static NotificationRepositoryInMemory Instance { get { return instance; } }
    }
}
