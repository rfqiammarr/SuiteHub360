namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Facilities.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Facilities
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Facilities)}";
            public static class RouteTemplateFor
            {
                public const string FacilityId = "{FacilityId}";
            }
        }
    }
}
