using PhoneService.Application.Interfaces;
using PhoneService.Core.DTOs;
using PhoneService.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Services;

public class CatalogService : ICatalogService
{
	private readonly ICatalogRepository catalogRepository;

	public CatalogService(ICatalogRepository catalogRepository)
	{
		this.catalogRepository = catalogRepository;
	}
	public async Task<List<CatalogDTO>> GetCatalogs()
	{
		var result = await catalogRepository.GetCatalogs();
		return result;
	}
}
