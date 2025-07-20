namespace CodeCraft.Query.Utilities;

public class PaginationList<T> where T : class
{
    public PaginationList(IEnumerable<T> list, long total)
    {
        List = list;
        Total = total;
    }

    public long Total { get; set; }
    public IEnumerable<T> List { get; set; }
}