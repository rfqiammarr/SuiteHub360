namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Rooms
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Rooms)}";
            public static class RouteTemplateFor
            {
                public const string RoomId = "{RoomId}";
            }
        }
    }
}
