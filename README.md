# 👨‍💻 Телеграм бот для получения фото по запросу (RU)

В этом проекте я реализовал телеграмм-бота на языке C# с помощью библиотеки **"Telegram.Bot"**. Этот бот присылает фото по запросу пользователя (чат-бот использует **API Flickr**, чтобы получать изображения по ключевым словам, которые ввел пользователь).

## Для самостоятельного запуска бота вам необходимо:
#### 1. Создать бота в **BotFather** (бот для регистрации, настройки и управления другими telegram-ботами).
    1. Отправьте BotFather сообщение /newbot
    2. Введите название вашего бота
    3. Введите username бота (оно обязательно должно оканчиваться на слово “bot”). 
    4. После создания бота вы получите токен, который нужно будет в следующем шаге.
#### 2. В классе **APIManager** введите свой Flickr-API и токен вашего телеграмм-бота в поля соответствующих констант.
   ```c sharp
   public static class APIManager
   {
      public const string TELEGRAM_BOT_API = "ВАШ_API_Flickr";
      public const string FLICKR_API = "ВАШ_ТОКЕН_БОТА";
   }
   ```
#### 3. Сохраните и запустите приложение.
---
# 👨‍💻 Telegram bot for getting photos on demand (ENG)

In this project I implemented a Telegram bot in C# using **"Telegram.Bot"** library. This bot sends photos on user's request (the chatbot uses **API Flickr** to get images by keywords entered by the user).

## To run the bot yourself you need:
#### 1. Create a bot in **BotFather** (a bot for registering, customizing and managing other telegram bots).
    1. Send BotFather the message /newbot
    2. Enter the name of your bot
    3. Enter the bot's username (it must end with the word "bot"). 
    4. After creating the bot you will receive a token, which you will need in the next step.
#### 2. In the **APIManager** class, enter your Flickr-API and your telegram bot token in the fields of the corresponding constants.
 ```c sharp
 public static class APIManager
 {
    public const string TELEGRAM_BOT_API = "YOUR_API_Flickr";
    public const string FLICKR_API = "YOUR_TOKEN_BOT_API";
 }
 ```
#### 3. Save and run the application.
---
