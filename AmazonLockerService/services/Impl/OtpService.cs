using AmazonLockerService.models;
using AmazonLockerService.repository;
using AmazonLockerService.strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services
{

    public interface IOtpService
    {
        int GenerateOtp();
        bool ValidateOtp(int otpId);
    }

    public class OtpService : IOtpService
    {
        OtpGenerationStrategy _otpStrategy;
        public OtpService(OtpGenerationStrategy otpStrategy)
        {
            _otpStrategy = otpStrategy; 
        }
        
        public int GenerateOtp() {
            int otp = _otpStrategy.GenerateOtp();
            return otp;
        }
        public bool ValidateOtp(int otp)
        {
            if (otp < 100000 || otp > 1000000) return false;
            return true;
        }
    }
}
