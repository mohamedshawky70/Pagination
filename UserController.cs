[HttpGet("")]
//Pagination , Searching and Sorting
public async Task<IActionResult> GetAllAsync([FromQuery]FilterRequest filter, CancellationToken cancellationToken)
{
	//Searching
	var users =  _userManager.Users.AsQueryable();
	if (!string.IsNullOrEmpty(filter.SearchValue))
		users = users.Where(u => u.UserName!.Contains(filter.SearchValue));
	//Sorting
	//To know write the expression in OrderBy(--) install package System.Linq.Dynamic.Core and write using System.Linq.Dynamic.Core;
	if (!string.IsNullOrEmpty(filter.SortColumn))
		users = users.OrderBy($"{filter.SortColumn} {filter.SortDirection}");
		
	var response = users.Adapt<IEnumerable<UserResponse>>();
	//Pagination
	var userList = await PaginationList<UserResponse>.CreateAsync(response, filter.PageNumber, filter.PageSize);
	return Ok(userList);
}
