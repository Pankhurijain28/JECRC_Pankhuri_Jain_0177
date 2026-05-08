using System;
using System.Threading.Tasks;

class AsyncService
{
    protected int requestCount;
    protected long lastResponseTime;

    public virtual async Task<string> FetchDataAsync(string endpoint)
    {
        await Task.Delay(2000);
        return "Base Fetch";
    }

    public virtual async Task<string> GetStatusAsync()
    {
        await Task.Delay(100);
        return "Base Status";
    }
}

class WeatherService : AsyncService
{
    private string city;
    private int temperature;

    public WeatherService(string city, int temperature)
    {
        this.city = city;
        this.temperature = temperature;
    }

    public override async Task<string> FetchDataAsync(string endpoint)
    {
        requestCount++;

        Console.WriteLine($"Weather Fetch Started,{city}");

        await Task.Delay(2000);

        string result = $"Weather Data Received,{city},{temperature}°C";
        Console.WriteLine(result);

        return result;
    }

    public override async Task<string> GetStatusAsync()
    {
        string status = $"Weather Service Status,Requests:{requestCount}";
        Console.WriteLine(status);

        return await Task.FromResult(status);
    }
}

class StockService : AsyncService
{
    private string symbol;
    private double currentPrice;

    public StockService(string symbol, double currentPrice)
    {
        this.symbol = symbol;
        this.currentPrice = currentPrice;
    }

    public override async Task<string> FetchDataAsync(string endpoint)
    {
        requestCount++;

        Console.WriteLine($"Stock Fetch Started,{symbol}");

        await Task.Delay(2000);

        string result = $"Stock Price Update,{symbol},${currentPrice}";
        Console.WriteLine(result);

        return result;
    }

    public override async Task<string> GetStatusAsync()
    {
        string status = $"Stock Service Status,Requests:{requestCount}";
        Console.WriteLine(status);

        return await Task.FromResult(status);
    }
}

class Program
{
    static async Task Main()
    {
        string serviceType = Console.ReadLine().Trim();
        string identifier = Console.ReadLine().Trim();
        string command = Console.ReadLine().Trim();

        AsyncService service;

        if (serviceType == "Weather")
        {
            service = new WeatherService(identifier, 22);
        }
        else
        {
            service = new StockService(identifier, 150.75);
        }

        if (command == "FetchDataAsync")
        {
            await service.FetchDataAsync(identifier);
        }
        else if (command == "GetStatusAsync")
        {
            await service.GetStatusAsync();
        }
    }
}