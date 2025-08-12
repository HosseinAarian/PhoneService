using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using PhoneService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.Repositories;
public class PhoneRepository : IPhoneRepository
{
	private readonly PhoneServiceDBContext context;

	public PhoneRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Phone>> GetAllAsync()
	{
		return await context.Phones.Include(p => p.PhoneBrand).ToListAsync();
	}

	public async Task<Phone> GetByIdAsync(int id)
	{
		return await context.Phones.Include(p => p.PhoneBrand)
					.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task AddAsync(Phone phone)
	{
		context.Phones.Add(phone);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Phone phone)
	{
		context.Phones.Update(phone);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var phone = await context.Phones.FindAsync(id);
		if (phone != null)
		{
			context.Phones.Remove(phone);
			await context.SaveChangesAsync();
		}
	}
}
