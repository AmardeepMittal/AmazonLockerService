using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Notification
    {
        public string Id { get; set; }
        public User User { get; set; }
        public DateTime SentDate { get; set; }
        public string Message { get; set; }

        public Notification(string id, User user, DateTime sentDate, string message) { 
            Id = id;
            User = user;
            SentDate = sentDate;
            Message = message;
        }
    }
}
