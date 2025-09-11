namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class RoomTypes
        {
            public const string Segment = $"{nameof(V1)}/{nameof(RoomTypes)}";
            public static class RouteTemplateFor
            {
                public const string RoomTypeId = "{RoomTypeId}";
            }
        }
    }
}
