using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;
public class PhoneBrandService(IPhoneBrandRepositories repository) : IPhoneBrandService
{
	public Task<IEnumerable<PhoneBrand>> GetAllAsync() => repository.GetAllAsync();

	public Task<PhoneBrand> GetByIdAsync(int id) => repository.GetByIdAsync(id);

	public Task CreateAsync(PhoneBrand brand) => repository.AddAsync(brand);

	public Task UpdateAsync(PhoneBrand brand) => repository.UpdateAsync(brand);

	public Task DeleteAsync(int id) => repository.DeleteAsync(id);
}
