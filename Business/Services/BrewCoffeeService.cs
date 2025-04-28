using Business.DTO;
using Commons.Helpers;

namespace Business.Services;

public class BrewCoffeeService : IBrewCoffeeService
{
    private int _count;

    public virtual void CountRequest()
    {
        _count++;
    }

    public virtual bool IsEveryFifthRequest()
    {
        return _count % 5 == 0;
    }

    public virtual bool IsOnApril1st(DateTime  date)
    {
        return date.Month == 4 && date.Day == 1;
    }
    
    public virtual BrewCoffeeDto GetInfo()
    {
        return new BrewCoffeeDto()
        {
            Message = "Your piping hot coffee is ready",
            Prepared = KoreaDateTimeHelper.Now()
        };
    }
}