using ConsoleClient.Models;

public class Program
{
    public static async Task Main(string[] args)
    {
        var messageSender = new MessageSender();
        
        var replies = await messageSender.SendMessage();

        for (int i = 1; i < replies.Count + 1; i++)
        {
            Console.WriteLine($"Reply - {i}");
            
            Console.WriteLine(replies[i - 1].Error);
            Console.WriteLine(replies[i - 1].IsSuccess);
            
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}