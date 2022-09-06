﻿using System;
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
    public class HandleCallbackQuerys
    {

        public async Task HandleCallbackQuery(ITelegramBotClient bot, CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data.StartsWith("download"))
            {
                int id = int.Parse(callbackQuery.Data.Split('_')[1]);
                //ChatFiles file = new HandleChatFiles().Files[id]; ;
                //using (Stream sw = System.IO.File.OpenWrite(@"DownloadFiles\" + file.Name))
                //    await bot.GetInfoAndDownloadFileAsync(file.Id, sw);
                //await bot.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Файл <b>{file.Name}</b> сохранен!",ParseMode.Html);
                return;
            }
            await bot.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"You choose with data: {callbackQuery.Data}");
            return;
        }
    }
}
