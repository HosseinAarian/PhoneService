using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.IRepositories;

public interface IServiceRepository
{
	Task<IEnumerable<Service>> GetAllAsync();
	Task<Service> GetByIdAsync(int id);
	Task AddAsync(Service entity);
	Task UpdateAsync(Service entity);
	Task DeleteAsync(int id);
}
