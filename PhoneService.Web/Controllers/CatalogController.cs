using Microsoft.AspNetCore.Mvc;
using PhoneService.Application.Interfaces;

namespace PhoneService.Web.Controllers;

public class CatalogController(ICatalogService catalogService) : Controller
{
	public async Task<IActionResult> Index()
	{
		var catalog = await catalogService.GetCatalogs();

		return View(catalog);
	}
}
