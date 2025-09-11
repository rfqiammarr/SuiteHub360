namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Roles
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Roles)}";
            public static class RouteTemplateFor
            {
                public const string RoleId = "{RoleId}";
            }
        }
    }
}
