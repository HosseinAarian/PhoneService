using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;

public class ItemService : IItemService
{
	private readonly IItemRepository repository;

	public ItemService(IItemRepository repository)
	{
		this.repository = repository;
	}

	public async Task<IEnumerable<Item>> GetAllAsync()
	{
		return await repository.GetAllAsync();
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
