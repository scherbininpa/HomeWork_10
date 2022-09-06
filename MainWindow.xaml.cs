using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Telegram;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace HomeWork_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotSettings botSettings = new BotSettings();
        HandlerUpdates handlerUpdates;
        HandleErrors handleErrors = new HandleErrors();
        TelegramBotClient bot;
        public MainWindow()
        {
            InitializeComponent();
            bot = new TelegramBotClient(botSettings.Token);
            var cts = new CancellationTokenSource();
            handlerUpdates = new HandlerUpdates(this);
            if (File.Exists("history.json"))
                handlerUpdates.messageLog = JsonConvert.DeserializeObject<ObservableCollection<MessageLog>>(File.ReadAllText("history.json"));
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = {}
            };
            bot.StartReceiving(handlerUpdates.HandleUpdatesAsync, handleErrors.HandleError, receiverOptions, cts.Token);
            // cts.Cancel();
            LogList.ItemsSource = handlerUpdates.messageLog;
        }

        private void btnMsgClick(object sender, RoutedEventArgs e)
        {
            if (CheckSendMessage())
            {
                bot.SendTextMessageAsync(Convert.ToInt64(textBlockID.Text), txtMsgSend.Text);
                txtMsgSend.Text = string.Empty;
                textBlockError.Text = String.Empty;
            }
            
        }

        private bool CheckSendMessage()
        {
            if (txtMsgSend.Text == String.Empty)
            {
                textBlockError.Text = "Нет сообщения для отправки";
                DelayMessageError();
                return false;
            }
            if (textBlockID.Text == String.Empty)
            {
                textBlockError.Text = "Получатель сообщения не выбран!";
                DelayMessageError();
                return false;
            }
            else { return true; }
        }
        private async void DelayMessageError()
        {
            await Task.Delay(5000);
            textBlockError.Text = String.Empty;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if File.Exists("history.json")
            File.WriteAllText("history.json",JsonConvert.SerializeObject(handlerUpdates.messageLog));
        }
    }
}
