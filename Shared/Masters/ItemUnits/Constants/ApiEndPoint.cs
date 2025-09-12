namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class ItemUnits
        {
            public const string Segment = $"{nameof(V1)}/{nameof(ItemUnits)}";
            public static class RouteTemplateFor
            {
                public const string ItemUnitId = "{itemUnitsId}";
            }
        }
    }
}
