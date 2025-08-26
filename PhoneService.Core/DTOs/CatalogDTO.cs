using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.DTOs;

public class CatalogDTO
{
	public int PhoneBrandId { get; set; }
	public string PhoneBrandTitle { get; set; }
	public List<ItemDTO> ItemDTOs { get; set; }
}
