using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Notification : BaseEntity
    {
        public User User { get; set; }
        public DateTime SentDate { get; set; }
        public string Message { get; set; }

        public Notification(int id, User user, DateTime sentDate, string message) { 
            Id = id;
            User = user;
            SentDate = sentDate;
            Message = message;
        }
    }
}
