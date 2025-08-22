using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Entities;
using System;

public class ServiceController : Controller
{
	private readonly AppDbContext db = new AppDbContext();

	// GET: Services
	public ActionResult Index()
	{
		return View(db.Services.ToList());
	}

	// GET: Services/Details/5
	public ActionResult Details(int id)
	{
		var service = db.Services.Find(id);
		if (service == null) return HttpNotFound();
		return View(service);
	}

	// GET: Services/Create
	public ActionResult Create()
	{
		return View();
	}

	// POST: Services/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(Service service)
	{
		if (ModelState.IsValid)
		{
			db.Services.Add(service);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View(service);
	}

	// GET: Services/Edit/5
	public ActionResult Edit(int id)
	{
		var service = db.Services.Find(id);
		if (service == null) return HttpNotFound();
		return View(service);
	}

	// POST: Services/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(Service service)
	{
		if (ModelState.IsValid)
		{
			db.Entry(service).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View(service);
	}

	// GET: Services/Delete/5
	public ActionResult Delete(int id)
	{
		var service = db.Services.Find(id);
		if (service == null) return HttpNotFound();
		return View(service);
	}

	// POST: Services/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public ActionResult DeleteConfirmed(int id)
	{
		var service = db.Services.Find(id);
		db.Services.Remove(service);
		db.SaveChanges();
		return RedirectToAction("Index");
	}
}
