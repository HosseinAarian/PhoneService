using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Entities;
public class Item
{
	public int Id { get; set; }
	public decimal Price { get; set; }

	public int PhoneId { get; set; }
	public Phone Phone { get; set; }

	public int ServiceId { get; set; }
	public Service Service { get; set; }
}
