using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using PhoneService.Infrastructure.Context;

namespace PhoneService.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
	private readonly PhoneServiceDBContext context;

	public ItemRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Item>> GetAllAsync()
	{
		return await context.Items
			.Include(i => i.Phone).ThenInclude(p => p.PhoneBrand)
			.Include(i => i.Service)
			.ToListAsync();
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
