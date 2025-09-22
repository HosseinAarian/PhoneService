using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;

public class PhoneService(IPhoneRepository phoneRepository) : IPhoneService
{
	public async Task<IEnumerable<Phone>> GetAllPhonesAsync()
	{
		return await phoneRepository.GetAllAsync();
	}

	public async Task<Phone> GetPhoneByIdAsync(int id)
	{
		return await phoneRepository.GetByIdAsync(id);
	}

	public async Task CreatePhoneAsync(Phone phone)
	{
		await phoneRepository.AddAsync(phone);
	}

	public async Task UpdatePhoneAsync(Phone phone)
	{
		await phoneRepository.UpdateAsync(phone);
	}

	public async Task DeletePhoneAsync(int id)
	{
		await phoneRepository.DeleteAsync(id);
	}
}
