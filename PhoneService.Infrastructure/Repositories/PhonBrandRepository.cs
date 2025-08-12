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
public class PhonBrandRepository : IPhoneBrandRepositories
{
	private readonly PhoneServiceDBContext context;

	public PhonBrandRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<PhoneBrand>> GetAllAsync()
	{
		return await context.PhoneBrands.ToListAsync();
	}

	public async Task<PhoneBrand> GetByIdAsync(int id)
	{
		return await context.PhoneBrands.FindAsync(id);
	}

	public async Task AddAsync(PhoneBrand entity)
	{
		context.PhoneBrands.Add(entity);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(PhoneBrand entity)
	{
		context.PhoneBrands.Update(entity);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await context.PhoneBrands.FindAsync(id);
		if (entity != null)
		{
			context.PhoneBrands.Remove(entity);
			await context.SaveChangesAsync();
		}
	}
}
