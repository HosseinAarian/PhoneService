using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Entities;

public class Service
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }

	public ICollection<Item> Items { get; set; }
}
