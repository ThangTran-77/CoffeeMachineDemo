using Business.DTO;
using Business.Services;
using CoffeeMachineDemo.Controllers.API.V1;
using Commons.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest;

[TestClass]
public class CoffeeControllerTest
{
    [TestMethod]
    public async Task GetBrewCoffee_Returns418_OnApril1st()
    {
        // Arrange
        var mockService = new Mock<BrewCoffeeService>();
        mockService.Setup(s => s.IsOnApril1st(It.IsAny<DateTime>())).Returns(true);

        var controller = new CoffeeController(mockService.Object);

        // Act
        var result = await controller.GetBrewCoffee();

        // Assert
        Assert.IsInstanceOfType(result, typeof(ObjectResult));
        var objectResult = result as ObjectResult;
        Assert.AreEqual(418, objectResult.StatusCode);
        Assert.AreEqual("I’m a teapot", objectResult.Value);
    }

    [TestMethod]
    public async Task GetBrewCoffee_Returns503_OnEveryFifthRequest()
    {
        // Arrange
        var mockService = new Mock<BrewCoffeeService>();
        mockService.Setup(s => s.IsOnApril1st(It.IsAny<DateTime>())).Returns(false);
        mockService.Setup(s => s.IsEveryFifthRequest()).Returns(true);

        var controller = new CoffeeController(mockService.Object);

        // Act
        var result = await controller.GetBrewCoffee();

        // Assert
        Assert.IsInstanceOfType(result, typeof(ObjectResult));
        var objectResult = result as ObjectResult;
        Assert.AreEqual(503, objectResult.StatusCode);
    }

    [TestMethod]
    public async Task GetBrewCoffee_Returns200_WithBrewCoffeeDto()
    {
        // Arrange
        var info = new BrewCoffeeDto()
        {
            Message = "Your piping hot coffee is ready",
            Prepared = KoreaDateTimeHelper.Now()
        };
        var mockService = new Mock<BrewCoffeeService>();
        mockService.Setup(s => s.IsOnApril1st(It.IsAny<DateTime>())).Returns(false);
        mockService.Setup(s => s.IsEveryFifthRequest()).Returns(false);
        mockService.Setup(s => s.GetInfo()).Returns(info);

        var controller = new CoffeeController(mockService.Object);

        // Act
        var result = await controller.GetBrewCoffee();

        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        var dto = okResult.Value as BrewCoffeeDto;
        Assert.AreEqual(info, dto);
    }
}