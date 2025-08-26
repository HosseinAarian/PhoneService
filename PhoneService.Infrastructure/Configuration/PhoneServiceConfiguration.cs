using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneService.Application.Interfaces;
using PhoneService.Application.Services;
using PhoneService.Core.IRepositories;
using PhoneService.Infrastructure.Context;
using PhoneService.Infrastructure.Repositories;


namespace PhoneService.Infrastructure.Configuration;

public partial class PhoneServiceConfiguration
{
	public static void Configure(IServiceCollection services, string dbConnectionString)
	{
		ConfigureDatabase(services, dbConnectionString);
		ConfigureRepositories(services);
		ConfigureServices(services);
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<IPhoneBrandService, PhoneBrandService>();
		services.AddTransient<IPhoneService, PhoneService.Application.Services.PhoneService>();
		services.AddTransient<IServiceService, ServiceService>();
		services.AddTransient<IItemService, ItemService>();
		services.AddTransient<ICatalogService, CatalogService>();
	}

	private static void ConfigureRepositories(IServiceCollection services)
	{
		services.AddTransient<IPhoneBrandRepositories, PhonBrandRepository>();
		services.AddTransient<IPhoneRepository, PhoneRepository>();
		services.AddTransient<IServiceRepository, ServiceRepository>();
		services.AddTransient<IItemRepository, ItemRepository>();
		services.AddTransient<ICatalogRepository, CatalogRepository>();
	}

	private static void ConfigureDatabase(IServiceCollection services, string connectionString)
	{
		services.AddDbContext<PhoneServiceDBContext>(option =>
		{
			option.UseSqlServer(connectionString,
				b => b.MigrationsAssembly("PhoneService.Infrastructure"));
		}, ServiceLifetime.Scoped);
	}
}

public partial class PhoneServiceConfiguration
{
	public static bool Migrate(IServiceProvider app)
	{
		try
		{
			var servicesScop = app.CreateScope();
			var services = servicesScop.ServiceProvider;
			var context = services.GetRequiredService<PhoneServiceDBContext>();
			context.Database.Migrate();
			servicesScop.Dispose();
			return true;
		}
		catch (Exception ex)
		{
			return false;
		}
	}
}
