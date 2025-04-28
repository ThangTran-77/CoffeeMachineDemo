using System.Net;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineDemo.Controllers.API.V1;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/v1/[controller]")]
public class CoffeeController : ControllerBase
{
    private BrewCoffeeService  _brewCoffeeService;

    public CoffeeController(BrewCoffeeService brewCoffeeService)
    {
        _brewCoffeeService = brewCoffeeService;
    }
    
    [HttpGet("/brew-coffee")]
    public async Task<ObjectResult> GetBrewCoffee()
    {
        if (_brewCoffeeService.IsOnApril1st(DateTime.Now))
        {
            return StatusCode(418,  "I’m a teapot");
        }
        
        _brewCoffeeService.CountRequest();
        
        return _brewCoffeeService.IsEveryFifthRequest() ? new ObjectResult(StatusCode(HttpStatusCode.ServiceUnavailable.GetHashCode())) : Ok(_brewCoffeeService.GetInfo());
    }
}