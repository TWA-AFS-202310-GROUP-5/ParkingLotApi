using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    public class ParkingLotAlreadyExistException : Exception
    {
        public ParkingLotAlreadyExistException() : base("Parking Lot Name already Exists.")
        {
        }

        public ParkingLotAlreadyExistException(string message) : base(message)
        {
        }

        public ParkingLotAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParkingLotAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
