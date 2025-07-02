using System;
using System.Runtime.Serialization;

namespace AmazonLockerService.services
{
    [Serializable]
    internal class NoSlotAvailableException : Exception
    {
        public NoSlotAvailableException()
        {
        }

        public NoSlotAvailableException(string message) : base(message)
        {
        }

        public NoSlotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSlotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}