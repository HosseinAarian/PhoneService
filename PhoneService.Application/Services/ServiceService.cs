using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;

public class ServiceService(IServiceRepository repository) : IServiceService
{
	public Task<IEnumerable<Service>> GetAllAsync() => repository.GetAllAsync();

	public Task<Service> GetByIdAsync(int id) => repository.GetByIdAsync(id);

	public Task CreateAsync(Service service) => repository.AddAsync(service);

	public Task UpdateAsync(Service service) => repository.UpdateAsync(service);

	public Task DeleteAsync(int id) => repository.DeleteAsync(id);
}
