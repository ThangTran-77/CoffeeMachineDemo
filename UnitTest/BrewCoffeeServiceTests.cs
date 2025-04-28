using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest;

[TestClass]
public class BrewCoffeeServiceTests
{
    [TestMethod]
    public void IsOnApril1st_ReturnsTrue_IfAprilFools()
    {
        var service = new BrewCoffeeService();
        var result = service.IsOnApril1st(new DateTime(2025, 4, 1));
        var resultFail = service.IsOnApril1st(new DateTime(2025, 8, 1));
        Assert.IsTrue(result);
        Assert.IsFalse(resultFail);
    }

    [TestMethod]
    public void IsEveryFifthRequest_ReturnsTrue_Every5Calls()
    {
        var service = new BrewCoffeeService();

        for (int i = 0; i < 4; i++) service.CountRequest(); // 1 to 4
        Assert.IsFalse(service.IsEveryFifthRequest());

        service.CountRequest(); // 5th
        Assert.IsTrue(service.IsEveryFifthRequest());
    }
}
