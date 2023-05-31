using Bot_Telegram;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
/*
 * Author: Ma Bach Duy sắp vip pro
 */
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


                
                else if (s2.StartsWith("tkhd"))
                {
                    string strconnect = "Data Source=DuyVPro;Initial Catalog=BTL;Integrated Security=True;Trust Server Certificate=True";
                    reply = "Đây là tất cả đơn hàng hiện có \n";
                    try
                    {
                        using (SqlConnection connect = new SqlConnection(strconnect))
                        {
                            connect.Open();
                            string sql = "select *from HDX";
                            using (SqlCommand command = new SqlCommand(sql, connect))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string column1Value = reader.GetString(0);
                                        string column2Value = reader.GetString(1);
                                        string column3Value = reader.GetString(2);
                                        string column4Value = reader.GetString(3);
                                        string column5Value = reader.GetString(4);
                                        string column6Value = reader.GetString(5);
                                        string column7Value = reader.GetString(6);
                                        string column8Value = reader.GetString(7);
                                        string column9Value = reader.GetString(8);
                                        string column10Value = reader.GetString(9);
                                        string messages = $"Mã kh: {column1Value}, tên kh: {column2Value}, mã sp: {column3Value}," +
                                            $"địa chỉ: {column4Value}, điện thoại: {column5Value}, số tk: {column6Value}, tên người bán: {column7Value}," +
                                            $"mã số thuế: {column8Value}, số lượng bán: {column9Value}, ngày bán: {column10Value}";
                                        reply += messages + "\n";
                                    }
                                }
                            }
                            connect.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        reply = ex.Message;
                    }
                }
                else if(s2.StartsWith("/help"))
                {
                    reply = "danh sách câu lệnh bạn có thể sử dụng\n" +
                        "1. gv\n" +
                        "2. tkdh - ( tìm kiếm hóa đơn )\n" +
                        "3. gptb2 - ( giải phương trình bậc 2 )\n" +
                        "4. themhd\n";
                }

                else if (s2.StartsWith("themhd"))
                {
                        reply = "Bạn muốn thêm ư? Hãy copy path ứng dụng này và dán nó vào file explorer của pc này \n" +
                        "D:\\Code\\Visual Studio\\solution\\dattaychiviec\\Noisql\\bin\\Debug\\net6.0-windows\\Noisql.exe\n" +
                        "Nhớ chọn Hóa đơn xuát nhé";
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
                MessageBox.Show("Lỗi này pri");
                AddLog(ErrorMessage);
                return Task.CompletedTask;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}