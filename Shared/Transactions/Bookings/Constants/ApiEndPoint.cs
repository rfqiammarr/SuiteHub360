namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.Bookings.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Bookings
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Bookings)}";
            public static class RouteTemplateFor
            {
                public const string BookingId = "{BookingId}";
            }
        }
    }
}
