using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.DTOs;

public class ItemDTO
{
	public int PhoneId { get; set; }
	public string PhoneTitle { get; set; }
	public int ServiceId { get; set; }
	public string ServiceTitle { get; set; }
	public int ItemId { get; set; }
	public decimal ItemPrice { get; set; }
}
