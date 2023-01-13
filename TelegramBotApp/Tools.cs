using System;
using System.IO;

namespace TelegramBotApp
{
    public class Tools
    {
        static string pathFolder, pathFile;
        public static void NewUserCheck(string UserId)
        {
            pathFolder = $"../../../Files/@{UserId}";
            pathFile = pathFolder + "/" + UserId + ".txt";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);

                File.CreateText(pathFile);
            }

        }
        public static void TextMessageSaver(string UserId, string UserMessage)
        {
           
            NewUserCheck(UserId);            
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
        public static void StickerMessageSaver(string UserId, string UserSticker)
        {
            NewUserCheck(UserId);
            try
            {
                StreamWriter writer = new StreamWriter(pathFile, true);
                writer.WriteLine(DateTime.Now + " | " + "прислал стикер " + UserSticker);
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка записи " + DateTime.Now + ex.Message);
            }
        }

        public static void PictureMessageSaver(string UserId, string UserPhoto)
        {
            NewUserCheck(UserId);
            try
            {
                StreamWriter writer = new StreamWriter(pathFile, true);
                writer.WriteLine(DateTime.Now + " | " + "прислал изображение " + UserPhoto);
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка записи " + DateTime.Now + ex.Message);
            }
        }
        public static void AnswerPhotoUpload(string UserId)
        {

        }
    }
}
