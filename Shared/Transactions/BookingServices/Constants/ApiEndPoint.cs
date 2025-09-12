namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.BookingServices.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class BookingServices
        {
            public const string Segment = $"{nameof(V1)}/{nameof(BookingServices)}";
            public static class RouteTemplateFor
            {
                public const string BookingServiceId = "{BookingServiceId}";
            }
        }
    }
}
