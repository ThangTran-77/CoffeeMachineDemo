using System.Net;
using Business.Services;
using Commons.Enum;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineDemo.Controllers.API.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CoffeeController(IBrewCoffeeService brewCoffeeService) : ControllerBase
{
    [HttpGet("brew-coffee")]
    public async Task<ObjectResult> GetBrewCoffee()
    {
        if (brewCoffeeService.IsOnApril1st(DateTime.Now))
        {
            return StatusCode(CustomHttpStatusEnumCode.ImATeapot.GetHashCode(),  "I’m a teapot");
        }
        
        brewCoffeeService.CountRequest();
        
        return brewCoffeeService.IsEveryFifthRequest() ? StatusCode(HttpStatusCode.ServiceUnavailable.GetHashCode(), String.Empty) : Ok(brewCoffeeService.GetInfo());
    }
}