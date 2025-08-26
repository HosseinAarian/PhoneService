using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using System;

public class ServiceController : Controller
{
	private readonly IServiceService service;

	public ServiceController(IServiceService service)
	{
		this.service = service;
	}

	public async Task<IActionResult> Index()
	{
		var services = await service.GetAllAsync();
		return View(services);
	}

	public async Task<IActionResult> Details(int id)
	{
		var phoneService = await service.GetByIdAsync(id);
		if (phoneService == null) return NotFound();
		return View(phoneService);
	}

	public IActionResult Create() => View();

	[HttpPost]
	public async Task<IActionResult> Create(Service phoneService)
	{
		//if (ModelState.IsValid)
		//{
		await service.CreateAsync(phoneService);
		return RedirectToAction(nameof(Index));
		//}
		//return View(brand);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var phoneService = await service.GetByIdAsync(id);
		if (phoneService == null) return NotFound();
		return View(phoneService);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Service phoneService)
	{
		await service.UpdateAsync(phoneService);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var phoneService = await service.GetByIdAsync(id);
		if (phoneService == null) return NotFound();
		return View(phoneService);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await service.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
