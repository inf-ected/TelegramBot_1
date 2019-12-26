using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MihaZupan; // HttpToSocks5Proxy
using Telegram.Bot;

namespace TelegramBot_1
{
    class Program
    {
        private static ITelegramBotClient botClient;
        static void Main(string[] args)
        {//"166.62.85.161", 47693 //"35.185.64.205", 1080
         // var proxy = new HttpToSocks5Proxy("35.185.64.205", 1080); //http://spys.one/proxys/US/
         //botClient = new TelegramBotClient("1013978767:AAF1ap9n2D6om6xjxfIRfVnuv2XavHkInn4", proxy) {Timeout=TimeSpan.FromSeconds(10) };
            botClient = new TelegramBotClient("1013978767:AAF1ap9n2D6om6xjxfIRfVnuv2XavHkInn4") { Timeout = TimeSpan.FromSeconds(10) };

            var me = botClient.GetMeAsync().Result;
            botClient.StartReceiving();
            
            Console.WriteLine($"Bot id:{me.Id}. Bot Name:{me.FirstName} ");


            botClient.OnMessage += BotClient_OnMessage;

            Console.ReadKey();
        }

        private static async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null) return;
            Console.WriteLine($"recived text message'{text}' in chat '{e.Message.Chat.Id}'");

            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"you said '{text}'"
                ).ConfigureAwait(false);
        }
    }
}
