using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneService.Application.Interfaces;
using PhoneService.Application.Services;
using PhoneService.Core.Entities;

namespace PhoneService.Web.Controllers;

public class ItemController(IItemService itemService, IPhoneService phoneService, IServiceService serviceService) : Controller
{
	public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
	{
		var items = await itemService.GetAllAsync(page, pageSize);
		return View(items);
	}

	public async Task<IActionResult> Create()
	{
		var phones = await phoneService.GetAllPhonesAsync();
		ViewData["Phone"] = new SelectList(phones, "Id", "Title");

		var services = await serviceService.GetAllAsync();
		ViewData["Service"] = new SelectList(services, "Id", "Title");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Price,PhoneId,ServiceId")] Item item)
	{
		await itemService.CreateAsync(item);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null) return NotFound();

		var item = await itemService.GetByIdAsync(id.Value);
		if (item == null) return NotFound();

		var phone = await phoneService.GetAllPhonesAsync();
		ViewData["Phone"] = new SelectList(phone, "Id", "Title");

		var service = await serviceService.GetAllAsync();
		ViewData["Service"] = new SelectList(service, "Id", "Title");

		return View(item);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Price,PhoneId,ServiceId")] Item item)
	{
		if (id != item.Id) return NotFound();

		await itemService.UpdateAsync(item);

		//var brands = await phoneBrandService.GetAllAsync();
		//ViewData["PhoneBrand"] = new SelectList(brands, "Id", "Title");
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var item = await itemService.GetByIdAsync(id);
		if (item == null) return NotFound();
		return View(item);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await itemService.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
