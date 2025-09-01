using Microsoft.EntityFrameworkCore;
using PhoneService.Core.DTOs;
using PhoneService.Core.IRepositories;
using PhoneService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Infrastructure.Repositories;

public class CatalogRepository : ICatalogRepository
{
	private readonly PhoneServiceDBContext context;

	public CatalogRepository(PhoneServiceDBContext context)
	{
		this.context = context;
	}

	//c
	public async Task<List<CatalogDTO>> GetCatalogs()
	{
		var result = await context.PhoneBrands
			.AsNoTracking()
			.Select(pb => new CatalogDTO
			{
				PhoneBrandId = pb.Id,
				PhoneBrandTitle = pb.Title,
				ItemDTOs = pb.Phones
				.SelectMany(ph => ph.Items.Select(i => new ItemDTO
				{
					PhoneId = ph.Id,
					PhoneTitle = ph.Title,
					ServiceId = i.ServiceId,
					ServiceTitle = i.Service.Title,
					ItemId = i.Id,
					ItemPrice = i.Price

				}))
				.ToList()
			})
			.ToListAsync();
		return result;
	}
}
