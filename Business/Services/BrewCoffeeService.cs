using Business.DTO;

namespace Business.Services;

public class BrewCoffeeService
{
    private int _count;

    public void CountRequest()
    {
        _count++;
    }

    public bool IsEveryFifthRequest()
    {
        return _count % 5 == 0;
    }

    public bool IsOnApril1st(DateTime  date)
    {
        return date.Month == 4 && date.Day == 1;
    }
    
    public BrewCoffeeDto GetInfo()
    {
        return null;
    }
}