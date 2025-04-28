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
        var pass = service.IsOnApril1st(new DateTime(2025, 4, 1));
        Assert.IsTrue(pass);
        
        var fail = service.IsOnApril1st(new DateTime(2025, 8, 1));
        Assert.IsFalse(fail);
    }

    [TestMethod]
    public void IsEveryFifthRequest_ReturnsTrue_Every5Calls()
    {
        var service = new BrewCoffeeService();

        // 1 to 4
        for (int i = 0; i < 4; i++)
        {
            service.CountRequest();
            Assert.IsFalse(service.IsEveryFifthRequest());
        }

        service.CountRequest(); // 5th
        Assert.IsTrue(service.IsEveryFifthRequest());
    }
}
