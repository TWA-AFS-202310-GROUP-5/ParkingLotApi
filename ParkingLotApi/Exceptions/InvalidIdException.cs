using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Id provided is not valid.")
        {
        }

        public InvalidIdException(string message) : base(message)
        {
        }

        public InvalidIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
