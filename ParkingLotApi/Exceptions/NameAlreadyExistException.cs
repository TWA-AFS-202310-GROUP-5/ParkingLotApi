namespace ParkingLotApi.Exceptions
{
    public class NameAlreadyExistException : Exception
    {
        public NameAlreadyExistException(): base("Parking lot name already exist") { }
    }
}
