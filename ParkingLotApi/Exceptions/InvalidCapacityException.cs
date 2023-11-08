namespace ParkingLotApi.Exceptions
{
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(): base("Capacity is out of range")
        {
        }
    }
}
