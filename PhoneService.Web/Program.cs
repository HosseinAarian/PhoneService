using PhoneService.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

PhoneServiceConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("PhoneServiceConnection"));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();

if (!PhoneServiceConfiguration.Migrate(app.Services))
	return;

app.Run();
