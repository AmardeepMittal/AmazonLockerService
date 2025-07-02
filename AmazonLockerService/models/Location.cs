using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.models
{
    public class Location
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
