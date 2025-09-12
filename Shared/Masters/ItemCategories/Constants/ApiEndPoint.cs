namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class ItemCategories
        {
            public const string Segment = $"{nameof(V1)}/{nameof(ItemCategories)}";
            public static class RouteTemplateFor
            {
                public const string ItemCategoryId = "{itemCategoryId}";
            }
        }
    }
}
