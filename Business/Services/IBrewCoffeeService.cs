using Business.DTO;

namespace Business.Services;

public interface IBrewCoffeeService
{
    BrewCoffeeDto GetInfo();
    void CountRequest();
    bool IsEveryFifthRequest();
    bool IsOnApril1st(DateTime date);
}