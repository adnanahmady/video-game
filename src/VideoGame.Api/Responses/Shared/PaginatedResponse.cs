namespace VideoGame.Api.Responses.Shared;

public class PaginatedResponse<T>
{
    public IEnumerable<T> Data { get; private set; }
    public MetaResource Meta { get; set; } = new();

    public PaginatedResponse(
        IEnumerable<T> data,
        int page,
        int pageSize,
        int totalItems)
    {
        Data = data;

        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        Meta.Pagination = new()
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}
