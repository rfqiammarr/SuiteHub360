namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Services
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Services)}";
            public static class RouteTemplateFor
            {
                public const string ServiceId = "{ServiceId}";
            }
        }
    }
}
