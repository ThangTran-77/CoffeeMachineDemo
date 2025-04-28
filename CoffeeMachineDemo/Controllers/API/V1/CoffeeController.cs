using System.Net;
using Business.Services;
using Commons.Enum;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineDemo.Controllers.API.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CoffeeController : ControllerBase
{
    private IBrewCoffeeService  _brewCoffeeService;

    public CoffeeController(IBrewCoffeeService brewCoffeeService)
    {
        _brewCoffeeService = brewCoffeeService;
    }
    
    [HttpGet("brew-coffee")]
    public async Task<ObjectResult> GetBrewCoffee()
    {
        if (_brewCoffeeService.IsOnApril1st(DateTime.Now))
        {
            return StatusCode(CustomHttpStatusEnuCode.ImATeapot.GetHashCode(),  "I’m a teapot");
            ;
        }
        
        _brewCoffeeService.CountRequest();
        
        return _brewCoffeeService.IsEveryFifthRequest() ? StatusCode(HttpStatusCode.ServiceUnavailable.GetHashCode(), String.Empty) : Ok(_brewCoffeeService.GetInfo());
    }
}