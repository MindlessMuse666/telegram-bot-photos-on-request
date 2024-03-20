namespace telegram_bot_photos_on_request;

public class Program
{
    static void Main(string[] args) 
    {
        var bot = new Bot(APIManager.TELEGRAM_BOT_API);

        bot.CreateCommands();
        bot.StartReceiving();
        Console.ReadLine();
    }
}