//From frontEnd
public record FilterRequest
{
	public int PageNumber { get; init; } = 1;
	public int PageSize { get; init; } = 10;
}
