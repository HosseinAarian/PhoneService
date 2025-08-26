using PhoneService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.IRepositories;

public interface ICatalogRepository
{
	Task<List<CatalogDTO>> GetCatalogs();
}
