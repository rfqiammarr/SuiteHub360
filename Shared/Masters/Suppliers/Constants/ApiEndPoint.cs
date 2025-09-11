namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Suppliers
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Suppliers)}";
            public static class RouteTemplateFor
            {
                public const string SupplierId = "{SupplierId}";
            }
        }
    }
}
