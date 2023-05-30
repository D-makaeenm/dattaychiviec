using Bot_Telegram;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot_Telegram
{
    public partial class Form1 : Form
    {

        TelegramBotClient botClient;


        int logCounter = 0;

        void AddLog(string msg)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke((MethodInvoker)delegate ()
                {
                    AddLog(msg);
                });
            }
            else
            {
                logCounter++;
                if (logCounter > 100)
                {
                    textBox1.Clear();
                    logCounter = 0;
                }
                textBox1.AppendText(msg + "\r\n");
            }
        }

        /// <summary>
        /// hàm tạo: ko kiểu, trùng tên với class
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            string token = "6019545263:AAHS-0MIBCXu5Y83mq6BE8eFznDhZEhsbR8";
            botClient = new TelegramBotClient(token);

            CancellationTokenSource cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,  //hàm xử lý khi có người chát đến
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            Task<User> me = botClient.GetMeAsync();

            AddLog($"Bot chạy nè: @{me.Result.Username}");

            //async lập trình bất đồng bộ
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {

                bool ok = false;

                //kdl? biến <=> biến đó có thể nhận NULL

                Telegram.Bot.Types.Message? message = null;

                if (update.Message != null)
                {
                    message = update.Message;
                    ok = true;
                }

                if (update.EditedMessage != null)
                {
                    message = update.EditedMessage;
                    ok = true;
                }

                if (!ok || message == null) return; //thoát ngay

                string messageText = message.Text;
                if (messageText == null) return;  //ko chơi với null

                var chatId = message.Chat.Id;  //id của người chát với bot

                AddLog($"{chatId}: {messageText}");  //show lên để xem
                string reply = "";  //đây là text trả lời

                string s2 = messageText.ToLower();


                /*
                 * Giai đoạn xử lý phần reply



                */
                string namebot = "duydithi_bot";

                if (s2.StartsWith("gv"))
                {
                    reply = "Chào mừng giảng viên tới với bot: " + namebot + "😲😲😲";
                }
                else if (s2.StartsWith("tkdh "))
                {
                    string tenkh = messageText.Substring(2);

                    timkiemdonhang tk = new timkiemdonhang();
                    reply = tk.timdonhang("%" + tenkh.Replace(' ', '%') + "%");
                }
                else if (s2.StartsWith("gptb2: "))
                {
                    string[] sep = { "gptb2:", "x^2", "x*x", "x", "=0", "= 0" };
                    string msg = messageText.ToLower();

                    string[] items = msg.Split(sep, StringSplitOptions.TrimEntries);
                    if (items.Length == 5)
                    {
                        try
                        {
                            items[1] = clsGPTB2.fix(items[1]);
                            items[2] = clsGPTB2.fix(items[2]);
                            items[3] = clsGPTB2.fixc(items[3]);

                            double a = double.Parse(items[1]);
                            double b = double.Parse(items[2]);
                            double c = double.Parse(items[3]);
                            reply = clsGPTB2.Giai(a, b, c);
                        }
                        catch (Exception ex)
                        {
                            reply = ex.Message;
                        }

                    }
                    else
                    {
                        reply = "Chưa nhập đúng định dạng: gptb2: ax^2+bx+c=0";
                    }
                }
                //else if (s2.StartsWith("tk"))
                //{
                //    string q = messageText.Substring(3);
                //    reply = timkiemDB.TimKiem(q);
                //}
                else
                {
                    reply = "Tôi khẳng định bạn nói là: " + messageText;
                }
                AddLog(reply); //show log to see

                // Echo received message text
                Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                       chatId: chatId,
                       text: reply,
                       parseMode: ParseMode.Html
                      );

                //đọc thêm về ParseMode.Html tại: https://core.telegram.org/bots/api#html-style
            }

            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };
                Console.WriteLine("Lỗi này pri");
                AddLog(ErrorMessage);
                return Task.CompletedTask;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}