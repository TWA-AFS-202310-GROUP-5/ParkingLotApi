namespace ParkingLotApi.Exceptions
{
    public class NameAlreadyExistException : Exception
    {
        public NameAlreadyExistException(): base("Parking lot aame already exist") { }
    }
}
