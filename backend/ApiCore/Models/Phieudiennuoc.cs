using System;
using System.Collections.Generic;

namespace ApiCore.Models
{
    public partial class Phieudiennuoc
    {
        public int Maphieu { get; set; }
        public int Manv { get; set; }
        public DateTime Ngaytaophieu { get; set; }
        public int Maphong { get; set; }
        public int Sodien { get; set; }
        public int Sonuoc { get; set; }
        public double Thanhtien { get; set; }
    }
}
