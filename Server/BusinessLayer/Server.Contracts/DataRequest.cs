namespace Server.Contracts
{
    public class DataRequest
    {
        public DataRequest()
        {
            Page = 1;
            PageSize = 10;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
