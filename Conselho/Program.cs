using Conselho;
using System.Text;
using System.Text.Json;

Console.WriteLine("Type something to get advice");
Console.ReadLine();

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
