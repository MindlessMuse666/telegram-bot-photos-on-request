using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Polling;

namespace telegram_bot_photos_on_request;

public class Bot
{
    private readonly TelegramBotClient _botClient;

    public Bot(string token)
    {
        _botClient = new TelegramBotClient(token);
    }

    public void CreateCommands()
    {
        _botClient.SetMyCommandsAsync(new List<BotCommand>()
        {
            new()
            {
                Command = CustomBotCommands.START,
                Description = "Запустить бота."
            },
            new()
            {
                Command = CustomBotCommands.ABOUT,
                Description = "Что делает бот и как им пользоваться?"
            }
        });
    }

    public void StartReceiving()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new UpdateType[] { UpdateType.Message }
        };
        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleError,
            receiverOptions,
            cancellationToken);
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;

        if (string.IsNullOrEmpty(update.Message.Text))
        {
            await _botClient.SendTextMessageAsync(chatId,
                text: "Данный бот принимает только текстовые сообщения.\n" +
                      "Введите ваш запрос правильно.",
                cancellationToken: cancellationToken);
            return;
        }

        var messageText = update.Message.Text;

        if (IsStartCommand(messageText))
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Привет, я бот по поиску картинок. Введите ваш запрос.",
                cancellationToken: cancellationToken);
            return;
        }

        if (IsAboutCommand(messageText))
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Данный бот возвращает 1 картинку по запросу пользователя. \n" +
                      "Чтобы получить картинку, введите текстовый запрос.",
                cancellationToken: cancellationToken);
            return;
        }

        await SendPhotoAsync(chatId, messageText, cancellationToken);
    }

    private Task HandleError(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }

    private bool IsStartCommand(string messageText) => messageText.ToLower() == CustomBotCommands.START;

    private bool IsAboutCommand(string messageText) => messageText.ToLower() == CustomBotCommands.ABOUT;

    private async Task SendPhotoAsync(long chatId, string request, CancellationToken cancellationToken)
    {
        var photoUrl = await FlickrAPI.GetPhotoUrlAsync(request);

        if (photoUrl == null)
        {
            await _botClient.SendTextMessageAsync(chatId,
                "Изображений не найдено.",
                cancellationToken: cancellationToken);
            return;
        }

        await _botClient.SendPhotoAsync(chatId: chatId,
            photo: new InputFileUrl(photoUrl),
            cancellationToken: cancellationToken);
    }
}