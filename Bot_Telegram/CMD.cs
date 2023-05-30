using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot.Types;

namespace Bot_Telegram
{
    public class ClassCMD
    {

        public static string kq = "";
        public static bool done = false;
        private static List<string> commands = new List<string>() { "dir", "type", "ipconfig", "ping", "tracert", "taskkill", "attrib", "copy" };
        public static void RUN(string cmd, int timeout = 10000)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            try
            {
                kq = "";
                done = false;

                timer.Interval = timeout;
                timer.Elapsed += (object? sender, ElapsedEventArgs e) => { done = true; };

                bool ok = false;
                foreach (string command in commands)
                {
                    if (cmd.StartsWith(command))
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    kq = "Lệnh không phù hợp";
                    done = true;
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardOutput = true;
                startInfo.WorkingDirectory = "c:\\";
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/c {cmd}";

                using (Process? exeProcess = Process.Start(startInfo))
                {
                    if (exeProcess != null)
                    {
                        timer.Elapsed += (object? sender, ElapsedEventArgs e) =>
                        {
                            //khi hết thời gian timeout thì code này chạy
                            //đóng exe cmd đang chạy ngầm
                            exeProcess.Close();
                            exeProcess.Kill();
                            done = true;
                        };
                        timer.Start();
                        exeProcess.WaitForExit(timeout);
                        while (done == false && !exeProcess.StandardOutput.EndOfStream)
                        {
                            string? line = exeProcess.StandardOutput.ReadLine();
                            // do something with line
                            if (line == null) break;
                            kq += (line + "\r\n");
                        }
                    }
                    done = true;
                    if (exeProcess != null) exeProcess.Kill();
                }
            }
            catch (Exception ex)
            {
                kq += ($"ERROR: {ex.Message}");
                done = true;
            }
            finally
            {
                timer.Stop();
                timer.Dispose();
                done = true;
            }
        }
    }
}
