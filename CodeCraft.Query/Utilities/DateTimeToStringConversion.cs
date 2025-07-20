using System.Data;
using System.Globalization;
using Dapper;

namespace CodeCraft.Query.Utilities;

public class DateTimeToStringConversion : SqlMapper.TypeHandler<string?>
{
    private const string DateFormat = "yyyy/MM/dd hh:mm tt";

    public override void SetValue(IDbDataParameter parameter, string? value)
    {
        parameter.Value = DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
            out var dateTime)
            ? dateTime
            : DBNull.Value;
    }

    public override string? Parse(object value)
    {
        return value is DateTime dateTime
            ? dateTime.ToString(DateFormat, CultureInfo.InvariantCulture)
            : value.ToString();
    }
}