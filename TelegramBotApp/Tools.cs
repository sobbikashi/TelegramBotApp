using System;
using System.IO;

namespace TelegramBotApp
{
    public class Tools
    {
        static string pathFolder, pathFile;
        public static void MessageSaver(string UserId, string UserMessage)
        {
            pathFolder = $"../../../Files/@{UserId}";
            pathFile = pathFolder + "/" + UserId + ".txt";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);

                File.CreateText(pathFile);
            }
            else
            {
                try
                {
                    StreamWriter writer = new StreamWriter(pathFile, true);
                    writer.WriteLine(DateTime.Now + " | " + UserMessage);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка записи " + DateTime.Now + ex.Message);
                }
            }
        }
    }
}
