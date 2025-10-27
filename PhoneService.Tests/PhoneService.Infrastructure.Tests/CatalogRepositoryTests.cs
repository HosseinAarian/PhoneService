using Microsoft.EntityFrameworkCore;
using PhoneService.Infrastructure.Context;
using PhoneService.Infrastructure.Repositories;
using PhoneService.Core.Entities;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace PhoneService.Infrastructure.Tests;

public class CatalogRepositoryTests
{
    private PhoneServiceDBContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<PhoneServiceDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_Catalog")
            .Options;

        var context = new PhoneServiceDBContext(options);
        return context;
    }

    [Fact]
    public async Task GetCatalogs_ReturnsCatalogDTOs()
    {
        using var context = CreateInMemoryContext();

        var brand = new PhoneBrand { Id = 1, Title = "Brand1", Phones = new List<Phone>() };
        var phone = new Phone { Id = 1, Title = "P1", PhoneBrand = brand, Items = new List<Item>() };
        var service = new Service { Id = 1, Title = "SRV1" };
        var item = new Item { Id = 1, Price = 100, Phone = phone, Service = service };

        brand.Phones.Add(phone);
        phone.Items.Add(item);

        context.PhoneBrands.Add(brand);
        context.Phones.Add(phone);
        context.Services.Add(service);
        context.Items.Add(item);
        await context.SaveChangesAsync();

        var repo = new CatalogRepository(context);
        var results = await repo.GetCatalogs();

        Assert.NotNull(results);
        Assert.Single(results);
        var catalog = results.First();
        Assert.Equal(1, catalog.PhoneBrandId);
        Assert.Equal("Brand1", catalog.PhoneBrandTitle);
        Assert.Single(catalog.ItemDTOs);
        var dto = catalog.ItemDTOs.First();
        Assert.Equal(1, dto.PhoneId);
        Assert.Equal(1, dto.ItemId);
        Assert.Equal(100, dto.ItemPrice);
    }
}
