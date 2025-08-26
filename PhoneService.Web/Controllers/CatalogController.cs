using Microsoft.AspNetCore.Mvc;
using PhoneService.Application.Interfaces;

namespace PhoneService.Web.Controllers;

public class CatalogController : Controller
{
	private readonly ICatalogService catalogService;

	public CatalogController(ICatalogService catalogService)
	{
		this.catalogService = catalogService;
	}

	public async Task<IActionResult> Index()
	{
		var catalog = await catalogService.GetCatalogs();

		return View(catalog);
	}
}
