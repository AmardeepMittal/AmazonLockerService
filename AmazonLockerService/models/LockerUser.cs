using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }

        public User(int id, string name, Contact contact, Location location)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Location = location;
        }
    }

    public class Client : User {
        public Client(int id, string name, Contact contact, Location location) : base(id, name, contact, location) { }
    }
    public class DeliveryPerson : User {
        public DeliveryPerson(int id, string name, Contact contact, Location location) : base(id, name, contact, location) { }
    }
}
