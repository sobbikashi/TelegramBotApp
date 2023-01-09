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
            var defaultFolderName = message.Chat.Id.ToString();
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName } | {message.Text}");
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Ну привет");
                    return;
                }
            }
            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "downloaded");

                var fileId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"E:\УЧЁБА\Repos\TelegramBotApp\TelegramBotApp\Files\" + message.Chat.Id.ToString() + @"\" + message.Document.FileName;

                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(filePath, fileStream);
                fileStream.Close();


                return;
            }
            if (message.Sticker != null)
            {
                Console.WriteLine($"{message.Chat.FirstName} | {"sent a sticker"}");
                await botClient.SendTextMessageAsync(message.Chat.Id, "send nudes pls");
                return;
            }
            //if (message.Document != null)
            //{
            //    await botClient.SendTextMessageAsync(message.Chat.Id, "downloaded");

            //    var fileId = update.Message.Document.FileId;
            //    var fileInfo = await botClient.GetFileAsync(fileId);
            //    var filePath = fileInfo.FilePath;

            //    string destinationFilePath = $@"E:\УЧЁБА\Repos\TelegramBotApp\TelegramBotApp\Files\" + message.Chat.Id.ToString() + @"\" + message.Document.FileName;

            //    await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
            //    await botClient.DownloadFileAsync(filePath,fileStream);
            //    fileStream.Close();


            //    return;
            //}
        }

        async static Task Error(ITelegramBotClient arg1, Exception ex, CancellationToken arg3)
        {
           Console.WriteLine($"{ex}");
        }
    }
}
