using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using PhoneService.Core.VieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;

public class ItemService(IItemRepository repository) : IItemService
{
	public async Task<PagedResult<Item>> GetAllAsync(int page, int pageSize)
	{
		return await repository.GetAllAsync(page, pageSize);
	}

	public async Task<Item> GetByIdAsync(int id)
	{
		return await repository.GetByIdAsync(id);
	}

	public async Task CreateAsync(Item item)
	{
		await repository.AddAsync(item);
	}

	public async Task UpdateAsync(Item item)
	{
		await repository.UpdateAsync(item);
	}

	public async Task DeleteAsync(int id)
	{
		await repository.DeleteAsync(id);
	}
}
