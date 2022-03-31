using System;
using System.Collections.Generic;

namespace ApiCore.Models
{
    public partial class Taikhoan
    {
        public int Matk { get; set; }
        public string Tendangnhap { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Cvu { get; set; }
    }
}
