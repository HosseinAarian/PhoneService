using PhoneService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Interfaces;

public interface IServiceService
{
	Task<IEnumerable<Service>> GetAllAsync();
	Task<Service> GetByIdAsync(int id);
	Task CreateAsync(Service brand);
	Task UpdateAsync(Service brand);
	Task DeleteAsync(int id);
}
