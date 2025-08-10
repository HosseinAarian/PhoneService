using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.Repositories;
public class PhonBrandRepository : IPhoneBrandRepositories
{
	public Task<IEnumerable<PhoneBrand>> GetAllAsync()
	{
		throw new NotImplementedException();
	}
}
