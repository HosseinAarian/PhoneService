using PhoneService.Core.Entities;
using PhoneService.Core.VieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Interfaces;

public interface IItemService
{
	Task<PagedResult<Item>> GetAllAsync(int page, int pageSize);
	Task<Item> GetByIdAsync(int id);
	Task CreateAsync(Item phone);
	Task UpdateAsync(Item phone);
	Task DeleteAsync(int id);
}
