using AutoMapper;
using FluentAssertions;
using Shop.Query.Profiles;
using Xunit.Categories;

namespace Shop.UnitTests.Query.Profiles;

[UnitTest]
public class AutoMapperTests
{
    [Fact]
    public void Should_Mapper_ConfigurationIsValid()
    {
        // Arrange
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<EventToQueryModelProfile>()));

        // Act
        var act = mapper.ConfigurationProvider.AssertConfigurationIsValid;

        // Assert
        act.Should().NotThrow();
    }
}