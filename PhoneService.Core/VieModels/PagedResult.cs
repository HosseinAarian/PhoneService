using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.VieModels;

public class PagedResult<T>
{
	public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
	public int CurrentPage { get; set; }
	public int PageSize { get; set; }
	public int TotalItems { get; set; }

	public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
}
