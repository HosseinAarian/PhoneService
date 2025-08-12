using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.IRepositories;
public interface IPhoneBrandRepositories
{
	Task<IEnumerable<PhoneBrand>> GetAllAsync();
	Task<PhoneBrand> GetByIdAsync(int id);
	Task AddAsync(PhoneBrand entity);
	Task UpdateAsync(PhoneBrand entity);
	Task DeleteAsync(int id);
}
