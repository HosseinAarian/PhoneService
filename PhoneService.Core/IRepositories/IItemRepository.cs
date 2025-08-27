using PhoneService.Core.Entities;
using PhoneService.Core.VieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.IRepositories;

public interface IItemRepository
{
	Task<PagedResult<Item>> GetAllAsync(int page, int pageSize);
	Task<Item> GetByIdAsync(int id);
	Task AddAsync(Item item);
	Task UpdateAsync(Item item);
	Task DeleteAsync(int id);
}
