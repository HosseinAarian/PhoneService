using Moq;
using PhoneService.Application.Services;
using PhoneService.Application.Interfaces;
using PhoneService.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PhoneService.Application.Tests;

public class ServiceServiceTests
{
    [Fact]
    public async Task GetAllAsync_CallsRepositoryAndReturns()
    {
        var mockRepo = new Mock<IServiceRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Service>
        {
            new Service { Id = 1, Title = "S1" },
            new Service { Id = 2, Title = "S2" }
        } as IEnumerable<Service>);

        var service = new ServiceService(mockRepo.Object);

        var result = await service.GetAllAsync();

        Assert.NotNull(result);
        Assert.Collection(result,
            s => Assert.Equal("S1", s.Title),
            s => Assert.Equal("S2", s.Title));
    }

    [Fact]
    public async Task CreateAsync_CallsRepository()
    {
        var mockRepo = new Mock<IServiceRepository>();
        var service = new ServiceService(mockRepo.Object);

        var entity = new Service { Id = 3, Title = "New" };
        await service.CreateAsync(entity);

        mockRepo.Verify(r => r.AddAsync(entity), Times.Once);
    }
}
