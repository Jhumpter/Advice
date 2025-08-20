using Conselho;
using System.ComponentModel.Design;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello!");
Thread.Sleep(1000);
await GetAdvice();
await Menu();

async Task Menu()
{
    Console.WriteLine("1 - New advice");
    Console.WriteLine("2 - Exit");
    Console.Write("Choose an option: ");
    int option = 0;
    try
    {
        option = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input, please enter a number.");
        await Menu();
    }
    if (option == 1)
    {
        await GetAdvice();
        await Menu();
    }
    else if (option == 2)
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Invalid option, try again.");
        await Menu();
    }
}

async Task GetAdvice()
{
    using (HttpClient client = new HttpClient())
    {
        try
        {
            string response = await client.GetStringAsync("https://api.adviceslip.com/advice");
            var advice = JsonSerializer.Deserialize<Resposta>(response);
            Console.WriteLine(advice.slip.advice);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"We have a problem ({ex.Message})");
        }
    }
}

