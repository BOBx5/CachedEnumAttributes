    public static class EnumHelper
    {
        public static string? GetDescription<TEnum>(TEnum enumValue) where TEnum : struct, Enum
        {
            if (CachedEnumAttribute<TEnum, DescriptionAttribute>.CachedEnums.TryGetValue(enumValue, out var descAttribute))
            {
                return descAttribute?.Description;
            }
            return null;
        }
    }