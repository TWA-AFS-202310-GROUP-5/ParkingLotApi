namespace ParkingLotApi.Exceptions
{

    public class PageIndexException : Exception
    {
        public PageIndexException() : base("Page index should larger than 0")
        {

        }
    }
} 
