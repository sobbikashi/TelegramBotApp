using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5618268261:AAFRKNk-HKZvXOYPj_7Q-nAbTAbv0sLEtJk");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }     


        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;            
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName } | {message.Text}");
                Tools.TextMessageSaver(message.Chat.FirstName, message.Text);
                if (message.Text.ToLower().Contains("/help"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, 
                        "Список команд бота: \n" +
                        "/scan - ищет чёт \n" +
                        "/время - показывает время");
                    return;
                }
                else
                {
                    if (message.Text.ToLower().Contains("/время"))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"{DateTime.Now}");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Неизвестная команда");
                        return;
                    }

                }
                
            }
            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "картинка...");
                Tools.PictureMessageSaver(message.Chat.FirstName, message.Photo.ToString());               

                return;

                
            }
            if (message.Sticker != null)
            {
                Console.WriteLine($"{message.Chat.FirstName} | {"sent a sticker"}");
                Tools.StickerMessageSaver(message.Chat.FirstName, message.Sticker.SetName);
                await botClient.SendTextMessageAsync(message.Chat.Id, "send nudes pls");
                return;
            }
            if (message.Document != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "downloaded");

                var fileId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;


                string destinationFilePath = $"../../../Files/@{message.Chat.FirstName}/@{message.Document.FileName}";

                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(filePath, fileStream);
                fileStream.Close();


                return;
            }
            
        }

        async static Task Error(ITelegramBotClient arg1, Exception ex, CancellationToken arg3)
        {
           Console.WriteLine($"{ex}");
        }
    }
}
