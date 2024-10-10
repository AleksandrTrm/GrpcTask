namespace ConsoleClient.Models;

public class DecimalGenerator
{
    public const int MIN = 0;
    public const int MAX = Int32.MaxValue;
    public const int DECIMAL_PLACES = 10;
    
    private Random random = new Random();

    public decimal GenerateDecimal()
    {
        int wholeNumber = random.Next(MIN, MAX);
        
        decimal fractionalPart = (decimal)random.NextDouble() * (decimal)Math.Pow(10, DECIMAL_PLACES);
        
        decimal result = wholeNumber + fractionalPart / (decimal)Math.Pow(10, DECIMAL_PLACES);

        return result;
    }
}