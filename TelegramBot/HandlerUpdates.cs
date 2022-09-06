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
using System.Threading;
using System.Collections.ObjectModel;

namespace HomeWork_10
{
    public class HandlerUpdates
    {
        //private  HandleMessages hMessages = new HandleMessages();
        //private HandleCallbackQuerys handleCallbackQuerys = new HandleCallbackQuerys();
        private MainWindow mainWindow;
        public ObservableCollection<MessageLog> messageLog { get; set; }
        public HandlerUpdates(MainWindow window)
        {
            this.mainWindow = window;
            this.messageLog = new ObservableCollection<MessageLog>();
        }
        public async Task HandleUpdatesAsync(ITelegramBotClient bot, Update update, CancellationToken cansellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                mainWindow.Dispatcher.Invoke(() =>
                {
                    messageLog.Add(new MessageLog(update.Message.Chat.Id, update.Message.Chat.FirstName, update.Message.Text, DateTime.Now));
                });
                //await bot.SendTextMessageAsync(update.Message.Chat.Id,"hello");
                return;
            }
        }
    }
}

