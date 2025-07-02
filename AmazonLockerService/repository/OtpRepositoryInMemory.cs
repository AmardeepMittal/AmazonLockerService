using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public class OtpRepositoryInMemory
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        public void AddOtp(int id, int otp)
        {
            map.Add(id, otp);
        }

        public int GetOtp(int id)
        {
            if (!map.ContainsKey(id))
                //IdNotFoundException class should create and they should be used to throw exception
                throw new Exception("Id not found exception");
            return map[id];
        }
    }
}
