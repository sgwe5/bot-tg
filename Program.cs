using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


    var botClient = new TelegramBotClient("6913477662:AAHnd6ZTovcXtrdl4B2oP3FmS7MOkFv_Gv4");
    botClient.StartReceiving(Update, Error);
    Console.ReadLine();

async static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    throw new NotImplementedException();
}

async static Task Update(ITelegramBotClient Client, Update update, CancellationToken token)
{
    var message = update.Message;
    if (message == null)
        return;
    switch(message.Text)
    {
        case "/start":
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("Button 1", "https://www.google.com"),
                        }
            });
            await Client.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать ... , выбери команду: /coff ", replyMarkup: inlineKeyboard);
            break;
        case "/coff"://вкидывает рандомный коэффицент, вписаный заранее
            string[] decimalNumbers = { "1.21", "22.79", "7.89", "3.06", "2.47", "1.17", "27.64", "2.68", "1.88", "0.12" };
            Random rnd = new Random();
            int index = rnd.Next(decimalNumbers.Length); 
            string selectedNumber = decimalNumbers[index]; 
            await Client.SendTextMessageAsync(message.Chat.Id, $"В следующем раунде Lucky улетит на: {selectedNumber}");
            break;
        case "/keyboard":
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new KeyboardButton [] {"FAQ", "Коэффицент"}
            })
            {
                ResizeKeyboard = true,
            };
            await Client.SendTextMessageAsync(message.Chat.Id, "Выберите:", replyMarkup: keyboard);
            break;
    }
}
Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Ошибка телеграм АПИ:\n{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
        _ => exception.ToString()
    };
    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}




