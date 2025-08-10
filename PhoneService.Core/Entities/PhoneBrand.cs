using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Entities;

public class PhoneBrand
{
	public int Id { get; set; }
	public string Title { get; set; }

	public ICollection<Phone> Phones { get; set; }
}

