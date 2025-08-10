using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Entities;
public class Phone
{
	public int Id { get; set; }
	public int Title { get; set; }

	public int PhoneBrandId { get; set; }
	public PhoneBrand PhoneBrand { get; set; }

	public ICollection<Item> Items { get; set; }
}
