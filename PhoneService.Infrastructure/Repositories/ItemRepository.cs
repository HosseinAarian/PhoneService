using Azure;
using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using PhoneService.Core.VieModels;
using PhoneService.Infrastructure.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PhoneService.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
	private readonly PhoneServiceDBContext context;

	public ItemRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	public async Task<PagedResult<Item>> GetAllAsync(int page, int pageSize)
	{
		var query =  context.Items
			.Include(i => i.Phone).ThenInclude(p => p.PhoneBrand)
			.Include(i => i.Service);


		var totalItems = query.Count();

		var items = query
		.OrderBy(i => i.Phone.Title)
		.Skip((page - 1) * pageSize)
		.Take(pageSize)
		.ToList();

		var model = new PagedResult<Item>
		{
			Items = items,
			CurrentPage = page,
			PageSize = pageSize,
			TotalItems = totalItems
		};

		return model;
	}

	public async Task<Item> GetByIdAsync(int id)
	{
		return await context.Items
			.Include(i => i.Phone).ThenInclude(p => p.PhoneBrand)
			.Include(i => i.Service)
			.FirstOrDefaultAsync(i => i.Id == id);

	}

	public async Task AddAsync(Item item)
	{
		context.Items.Add(item);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Item item)
	{
		context.Items.Update(item);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var item = await context.Items.FindAsync(id);
		if (item != null)
		{
			context.Items.Remove(item);
			await context.SaveChangesAsync();
		}
	}	
}
