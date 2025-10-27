using Moq;
using PhoneService.Application.Interfaces;
using PhoneService.Application.Services;
using PhoneService.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PhoneService.Application.Tests;

public class PhoneServiceTests
{
    [Fact]
    public async Task GetAllPhonesAsync_ReturnsPhones()
    {
        var mockRepo = new Mock<IPhoneRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Phone>
        {
            new Phone { Id = 1, Title = "Phone1" },
            new Phone { Id = 2, Title = "Phone2" }
        } as IEnumerable<Phone>);

        var service = new PhoneService.Application.Services.PhoneService(mockRepo.Object);

        var result = await service.GetAllPhonesAsync();

        Assert.NotNull(result);
        Assert.Collection(result,
            p => Assert.Equal("Phone1", p.Title),
            p => Assert.Equal("Phone2", p.Title));
    }

    [Fact]
    public async Task GetPhoneByIdAsync_ReturnsPhone()
    {
        var mockRepo = new Mock<IPhoneRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Phone { Id = 1, Title = "Phone1" });

        var service = new PhoneService.Application.Services.PhoneService(mockRepo.Object);

        var result = await service.GetPhoneByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Phone1", result.Title);
    }

    [Fact]
    public async Task CreatePhoneAsync_CallsRepository()
    {
        var mockRepo = new Mock<IPhoneRepository>();
        var service = new PhoneService.Application.Services.PhoneService(mockRepo.Object);

        var phone = new Phone { Id = 3, Title = "Phone3" };
        await service.CreatePhoneAsync(phone);

        mockRepo.Verify(r => r.AddAsync(phone), Times.Once);
    }

    [Fact]
    public async Task UpdatePhoneAsync_CallsRepository()
    {
        var mockRepo = new Mock<IPhoneRepository>();
        var service = new PhoneService.Application.Services.PhoneService(mockRepo.Object);

        var phone = new Phone { Id = 1, Title = "Updated" };
        await service.UpdatePhoneAsync(phone);

        mockRepo.Verify(r => r.UpdateAsync(phone), Times.Once);
    }

    [Fact]
    public async Task DeletePhoneAsync_CallsRepository()
    {
        var mockRepo = new Mock<IPhoneRepository>();
        var service = new PhoneService.Application.Services.PhoneService(mockRepo.Object);

        await service.DeletePhoneAsync(1);

        mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
    }
}
