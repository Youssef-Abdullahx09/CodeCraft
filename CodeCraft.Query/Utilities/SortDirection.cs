using System.Runtime.Serialization;

namespace CodeCraft.Query.Utilities;

public enum SortDirection
{
    [EnumMember(Value = "ASC")] Asc = 1,
    [EnumMember(Value = "DESC")] Desc = 2
}