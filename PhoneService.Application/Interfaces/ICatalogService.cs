using PhoneService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Application.Interfaces;

public interface ICatalogService
{
	Task<List<CatalogDTO>> GetCatalogs();
}
