using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


    var client = new TelegramBotClient("6913477662:AAHnd6ZTovcXtrdl4B2oP3FmS7MOkFv_Gv4");
    client.StartReceiving(Update, Error);
    Console.ReadLine();

async static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    throw new NotImplementedException();
}

async static Task Update(ITelegramBotClient Client, Update update, CancellationToken token)
{
    var message = update.Message;
    if (message.Text != null && message.Text.ToLower() == "/start")
    {
        await Client.SendTextMessageAsync(message.Chat.Id, "Привет, подпишись пожалуйста:\t https://www.twitch.tv/cro_okedfinger");
    }
}
    static async Task Main(string[] args)
{
    string[] decimalNumbers = { "1.23", "4.56", "7.89", "2.34", "5.67", "8.90", "3.45", "6.78", "9.01", "0.12" };

    botClient.OnMessage += async (sender, e) =>
    {
        if (e.Message.Text != null)
        {
            if (e.Message.Text.ToLower() == "/randomdecimal")
            {
                Random rnd = new Random();
                int index = rnd.Next(decimalNumbers.Length); // Selects a random index from the array
                string selectedNumber = decimalNumbers[index]; // Retrieves the selected decimal number
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"Randomly selected decimal number: {selectedNumber}");

            }
        }
    };
    botClient.StartReceiving();
    Console.WriteLine("Bot started. Press any key to exit");
    Console.ReadKey();
    botClient.StopReceiving();
}


