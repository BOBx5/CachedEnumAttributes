using System.Reflection;

[AttributeUsage(AttributeTargets.Enum, AllowMultiple = true)]
public class CachedEnumAttribute<TEnum, TAttribute> : Attribute
    where TEnum : struct, Enum
    where TAttribute : Attribute
{
    public static Dictionary<TEnum, TAttribute?> CachedEnums => _cached.Value;
    private static Lazy<Dictionary<TEnum, TAttribute?>> _cached = new Lazy<Dictionary<TEnum, TAttribute?>>(() =>
    {
        var enumValues = Enum.GetValues<TEnum>();
        Dictionary<TEnum, TAttribute?> dictionary = new(enumValues.Length);
        foreach (var value in enumValues)
        {
            var memberInfo = typeof(TEnum).GetMember(value.ToString()).First();
            var targetAttribute = memberInfo.GetCustomAttribute<TAttribute>();
            dictionary.Add(value, targetAttribute);
        }
        return dictionary;
    });
}