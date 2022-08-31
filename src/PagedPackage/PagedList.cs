using Microsoft.EntityFrameworkCore;

namespace PagedPackage;

public class PagedList<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRows { get; set; }
    public int TotalPages { get; set; }
    public List<T>? Items { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }

    public async static Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        return new PagedList<T>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRows = await source.CountAsync(),
            TotalPages = (int)Math.Ceiling(source.Count() / (double)pageSize),
            Items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(),
            HasNextPage = (pageNumber < ((int)Math.Ceiling(source.Count() / (double)pageSize))),
            HasPreviousPage = (pageNumber > 1)
        };
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        return new PagedList<T>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(source.Count() / (double)pageSize),
            TotalRows = source.Count(),
            Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
            HasNextPage = (pageNumber < ((int)Math.Ceiling(source.Count() / (double)pageSize))),
            HasPreviousPage = (pageNumber > 1)
        };
    }
}