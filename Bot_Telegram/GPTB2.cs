using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Telegram
{
    public class clsGPTB2
    {
        public static string fix(string item)
        {
            if (item == "" || item == "+") return "1";
            if (item == "-") return "-1";
            return item;
        }
        public static string fixc(string item)
        {
            if (item == "") return "0";
            return item;
        }
        public static string Giai(double a, double b, double c)
        {
            string db, dc;
            if (b >= 0) db = "+"; else db = "";
            if (c >= 0) dc = "+"; else dc = "";
            string kq = $"Giải phương trình bậc 2: {a}x²{db}{b}x{dc}{c}=0\n";
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                kq += $"ptb2 có 2 nghiệm phân biệt\nx1={x1}\nx2={x2}";
            }
            else if (delta == 0)
            {
                double x12 = (-b) / (2 * a);
                kq += $"ptb2 có 2 nghiệm bằng nhau\nx1=x2={x12}";
            }
            else
            {
                kq += "ptb2 ko có nghiệm thực. (vô nghiệm)";
            }
            return kq;
        }
    }
}
