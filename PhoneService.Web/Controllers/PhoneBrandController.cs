using Microsoft.AspNetCore.Mvc;
using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;

namespace PhoneService.Web.Controllers;

public class PhoneBrandController : Controller
{
	private readonly IPhoneBrandService service;

	public PhoneBrandController(IPhoneBrandService service)
	{
		this.service = service;
	}

	public async Task<IActionResult> Index()
	{
		var brands = await service.GetAllAsync();
		return View(brands);
	}

	public async Task<IActionResult> Details(int id)
	{
		var brand = await service.GetByIdAsync(id);
		if (brand == null) return NotFound();
		return View(brand);
	}

	public IActionResult Create() => View();

	[HttpPost]
	public async Task<IActionResult> Create(PhoneBrand brand)
	{
		//if (ModelState.IsValid)
		//{
		await service.CreateAsync(brand);
		return RedirectToAction(nameof(Index));
		//}
		//return View(brand);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var brand = await service.GetByIdAsync(id);
		if (brand == null) return NotFound();
		return View(brand);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(PhoneBrand brand)
	{
		await service.UpdateAsync(brand);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var brand = await service.GetByIdAsync(id);
		if (brand == null) return NotFound();
		return View(brand);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await service.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
