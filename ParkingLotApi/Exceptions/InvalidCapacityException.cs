namespace ParkingLotApi.Exceptions
{
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(){}
        public InvalidCapacityException(string message) : base(message) { }
    }
}
