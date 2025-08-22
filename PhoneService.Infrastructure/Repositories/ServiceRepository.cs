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

public class ServiceRepository : IServiceRepository
{
	private readonly PhoneServiceDBContext context;

	public ServiceRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Service>> GetAllAsync()
	{
		return await context.Services.ToListAsync();
	}

	public async Task<Service> GetByIdAsync(int id)
	{
		return await context.Services.FindAsync(id);
	}

	public async Task AddAsync(Service entity)
	{
		context.Services.Add(entity);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Service entity)
	{
		context.Services.Update(entity);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await context.Services.FindAsync(id);
		if (entity != null)
		{
			context.Services.Remove(entity);
			await context.SaveChangesAsync();
		}
	}





	
}
