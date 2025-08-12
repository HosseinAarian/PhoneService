using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.IRepositories;

public interface IPhoneRepository
{
	Task<IEnumerable<Phone>> GetAllAsync();
	Task<Phone> GetByIdAsync(int id);
	Task AddAsync(Phone phone);
	Task UpdateAsync(Phone phone);
	Task DeleteAsync(int id);
}
