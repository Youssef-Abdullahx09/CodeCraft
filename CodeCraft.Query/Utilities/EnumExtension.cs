using System.Reflection;
using System.Runtime.Serialization;

namespace CodeCraft.Query.Utilities;

public static class EnumExtensions
{
    public static string GetValue<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        var enumField = typeof(TEnum).GetField(enumValue.ToString());
        var enumMemberAttr = enumField?.GetCustomAttribute<EnumMemberAttribute>();
        return enumMemberAttr?.Value ?? enumValue.ToString();
    }
}