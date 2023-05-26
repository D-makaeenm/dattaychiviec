using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Noisql
{
    internal class HDX
    {
        public String makh { get; set; }
        public String tenkh { get; set;}
        public String masp { get; set;}
        public String diachi { get; set;}   
        public String dienthoai { get; set;} 
        public String tennguoiban { get; set;}   
        public String masothue { get; set;}   
        public String sotk { get; set;}
        public String slban { get; set;}
        public String ngayban { get; set;}
        //public HDX()
        //{
        //}
        public HDX(string makh, string tenkh, string masp, string diachi, string dienthoai, string tennguoiban, string masothue, string sotk, string slban, string ngayban)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.masp = masp;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
            this.tennguoiban = tennguoiban;
            this.masothue = masothue;
            this.sotk = sotk;
            this.slban = slban;
            this.ngayban = ngayban;
        }
    }
}
