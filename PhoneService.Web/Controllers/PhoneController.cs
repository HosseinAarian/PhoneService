using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;

namespace PhoneService.Web.Controllers
{
	public class PhoneController : Controller
	{
		private readonly IPhoneService phoneService;
		private readonly IPhoneBrandService phoneBrandService;

		public PhoneController(IPhoneService phoneService, IPhoneBrandService phoneBrandService)
		{
			this.phoneService = phoneService;
			this.phoneBrandService = phoneBrandService;
		}

		public async Task<IActionResult> Index()
		{
			var phones = await phoneService.GetAllPhonesAsync();
			return View(phones);
		}

		public async Task<IActionResult> Create()
		{
			var brands = await phoneBrandService.GetAllAsync();
			ViewData["PhoneBrand"] = new SelectList(brands, "Id", "Title");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Title,PhoneBrandId")] Phone phone)
		{
			//if (ModelState.IsValid)
			//{
			await phoneService.CreatePhoneAsync(phone);
			return RedirectToAction(nameof(Index));
			//}
			//var brands = await phoneBrandService.GetAllAsync();
			//ViewData["PhoneBrandId"] = new SelectList(brands, "Id", "Title", phone.PhoneBrandId);
			//return View(phone);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var phone = await phoneService.GetPhoneByIdAsync(id.Value);
			if (phone == null) return NotFound();

			var brands = await phoneBrandService.GetAllAsync();
			ViewData["PhoneBrandId"] = new SelectList(brands, "Id", "Title", phone.PhoneBrandId);

			return View(phone);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PhoneBrandId")] Phone phone)
		{
			if (id != phone.Id) return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					await phoneService.UpdatePhoneAsync(phone);
				}
				catch (Exception)
				{
					// Handle concurrency exceptions, etc.
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			var brands = await phoneBrandService.GetAllAsync();
			ViewData["PhoneBrandId"] = new SelectList(brands, "Id", "Title", phone.PhoneBrandId);
			return View(phone);
		}
	}
}
