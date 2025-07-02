using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.util
{
    public class LocationUtil
    {
        public static int GetDistance(Location loc1, Location loc2) { 
            int X = loc2.X - loc1.X;
            int Y = loc2.Y - loc1.Y;
            return X*X - Y*Y;
        }
    }
}
