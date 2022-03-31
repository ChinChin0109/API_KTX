using System;
using System.Collections.Generic;

namespace ApiCore.Models
{
    public partial class Hoadon
    {
        public int Mahoadon { get; set; }
        public DateTime Ngayhoadon { get; set; }
        public string Phong { get; set; }
        public double Tienphong { get; set; }
        public double Tiendc { get; set; }
        public double Tongtien { get; set; }
        public int Masv { get; set; }
        public int Manv { get; set; }
        public int Maphieu { get; set; }
    }
}
