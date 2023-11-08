namespace ParkingLotApi.Exceptions
{
    public class IDNotExistException: Exception
    {
        public IDNotExistException(string id): base($"Parking Lot ID {id} Doesn't Exist")
        {

        }
    }
}
