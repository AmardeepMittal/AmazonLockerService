using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.strategy
{
    public class OtpGenerationStrategy
    {
        public int GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100001, 999999);
        }
    }
}
