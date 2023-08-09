using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApp
{
    public class Randomizer
    {
       

        public int GetRandom(Random random)
        {
            int result;
            return (result = random.Next(0, 100));
        }
    }
}
