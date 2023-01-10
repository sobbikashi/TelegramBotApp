using System;
using System.IO;

namespace TelegramBotApp
{
    public class Tools
    {
        string pathFolder, pathFile;
        public void MessageSaver(string UserId, string UserMessage)
        {
            pathFolder = $"E:/УЧЁБА/Repos/TelegramBotApp/TelegramBotApp/Files/@{UserId}";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                pathFile = pathFolder + "/" + UserId + ".txt";
                System.IO.File.CreateText(pathFile);
            }
            else
            {
                try
                {
                    StreamWriter writer = new StreamWriter(pathFile);
                    writer.WriteLine(UserMessage);
                    writer.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Ошибка записи " + DateTime.Now + ex.Message);
                }
            }
        }
    }
}
