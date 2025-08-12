using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Interfaces;
public interface IPhoneBrandService
{
	Task<IEnumerable<PhoneBrand>> GetAllAsync();
	Task<PhoneBrand> GetByIdAsync(int id);
	Task CreateAsync(PhoneBrand brand);
	Task UpdateAsync(PhoneBrand brand);
	Task DeleteAsync(int id);
}
