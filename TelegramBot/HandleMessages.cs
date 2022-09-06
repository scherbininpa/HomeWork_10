using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;

namespace HomeWork_10
{
    public class HandleMessages
    {
        private MainWindow _mainWindow;
        private TelegramBotClient bot;
        public HandleMessages(MainWindow window, ITelegramBotClient bot, Message message)
        { }
        public async Task HandleMessage(MainWindow window, ITelegramBotClient bot, Message message)
        {
            if (message.Text == "/start")
            {
                await bot.SendTextMessageAsync(message.Chat.Id, text: "Добро пожаловать");
            }

           // await bot.SendTextMessageAsync(message.Chat.Id, text: $"Вы сказали: {message.Text}");
        }
    }
}
