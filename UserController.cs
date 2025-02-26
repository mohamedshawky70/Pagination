[HttpGet("")]
public async Task<IActionResult> GetAllAsync([FromQuery]FilterRequest filter, CancellationToken cancellationToken)
{
	var users = await _userManager.Users.ToListAsync(cancellationToken);
	var response = users.Adapt<IEnumerable<UserResponse>>();
	var userList = await PaginationList<UserResponse>.CreateAsync(response, filter.PageNumber, filter.PageSize);
	return Ok(userList);
}
