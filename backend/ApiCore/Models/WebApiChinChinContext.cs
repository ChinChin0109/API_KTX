using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCore.Models
{
    public partial class WebApiChinChinContext : DbContext
    {

        public WebApiChinChinContext(DbContextOptions<WebApiChinChinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baocao> Baocao { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Hocsinh> Hocsinh { get; set; }
        public virtual DbSet<Hopdong> Hopdong { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phieudiennuoc> Phieudiennuoc { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<PhongInfo> PhongInfo { get; set; }
        public virtual DbSet<Quanly> Quanly { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Thenoitru> Thenoitru { get; set; }
        public virtual DbSet<Toanha> Toanha { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baocao>(entity =>
            {
                entity.HasKey(e => e.Mabcao)
                    .HasName("PK__BAOCAO__0DB8ECBE64E63A26");

                entity.ToTable("BAOCAO");

                entity.Property(e => e.Mabcao).HasColumnName("mabcao");

                entity.Property(e => e.Maql).HasColumnName("maql");

                entity.Property(e => e.Ndbc)
                    .IsRequired()
                    .HasColumnName("ndbc")
                    .HasMaxLength(1000);

                entity.Property(e => e.Ngaytaobcao)
                    .HasColumnName("ngaytaobcao")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfJoin).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(200);

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.PhotoFileName).HasMaxLength(500);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahoadon)
                    .HasName("PK__HOADON__8C708E0CC7CDF900");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahoadon).HasColumnName("mahoadon");

                entity.Property(e => e.Manv).HasColumnName("manv");

                entity.Property(e => e.Maphieu).HasColumnName("maphieu");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngayhoadon)
                    .HasColumnName("ngayhoadon")
                    .HasColumnType("datetime");

                entity.Property(e => e.Phong)
                    .IsRequired()
                    .HasColumnName("phong")
                    .HasMaxLength(30);

                entity.Property(e => e.Tiendc).HasColumnName("tiendc");

                entity.Property(e => e.Tienphong).HasColumnName("tienphong");

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            });

            modelBuilder.Entity<Hocsinh>(entity =>
            {
                entity.HasKey(e => e.Masv)
                    .HasName("PK__HOCSINH__7A21767CFD64F0A0");

                entity.ToTable("HOCSINH");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("gioitinh")
                    .HasMaxLength(10);

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasMaxLength(50);

                entity.Property(e => e.Lop)
                    .IsRequired()
                    .HasColumnName("lop")
                    .HasMaxLength(30);

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quequan)
                    .IsRequired()
                    .HasColumnName("quequan")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Hopdong>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__HOPDONG__7A2100DE7F569F72");

                entity.ToTable("HOPDONG");

                entity.Property(e => e.Mahd).HasColumnName("mahd");

                entity.Property(e => e.Maql).HasColumnName("maql");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngaytaohd)
                    .HasColumnName("ngaytaohd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tgbatdauhd)
                    .HasColumnName("tgbatdauhd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tgketthuchd)
                    .HasColumnName("tgketthuchd")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__7A21B37D82B0062C");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv).HasColumnName("manv");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasMaxLength(50);

                entity.Property(e => e.Matk).HasColumnName("matk");

                entity.Property(e => e.Sdt).HasColumnName("sdt");
            });

            modelBuilder.Entity<Phieudiennuoc>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__PHIEUDIE__A72B5185EB3F5DAD");

                entity.ToTable("PHIEUDIENNUOC");

                entity.Property(e => e.Maphieu).HasColumnName("maphieu");

                entity.Property(e => e.Manv).HasColumnName("manv");

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Ngaytaophieu)
                    .HasColumnName("ngaytaophieu")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sodien).HasColumnName("sodien");

                entity.Property(e => e.Sonuoc).HasColumnName("sonuoc");

                entity.Property(e => e.Thanhtien).HasColumnName("thanhtien");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.Maphong)
                    .HasName("PK__PHONG__BBA25480F2686A62");

                entity.ToTable("PHONG");

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Matoa).HasColumnName("matoa");

                entity.Property(e => e.Tang).HasColumnName("tang");

                entity.Property(e => e.Tenphong)
                    .IsRequired()
                    .HasColumnName("tenphong")
                    .HasMaxLength(50);

                entity.Property(e => e.Tinhtrang)
                    .IsRequired()
                    .HasColumnName("tinhtrang")
                    .HasMaxLength(50);

                entity.Property(e => e.Tsogiuong).HasColumnName("tsogiuong");
            });

            modelBuilder.Entity<PhongInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PHONG_INFO");

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Sohocsinh).HasColumnName("sohocsinh");

                entity.Property(e => e.Tang).HasColumnName("tang");

                entity.Property(e => e.Tenphong)
                    .IsRequired()
                    .HasColumnName("tenphong")
                    .HasMaxLength(50);

                entity.Property(e => e.Tinhtrang)
                    .IsRequired()
                    .HasColumnName("tinhtrang")
                    .HasMaxLength(100);

                entity.Property(e => e.Tsogiuong).HasColumnName("tsogiuong");
            });

            modelBuilder.Entity<Quanly>(entity =>
            {
                entity.HasKey(e => e.Maql)
                    .HasName("PK__QUANLY__7A21E80F35E0CD73");

                entity.ToTable("QUANLY");

                entity.Property(e => e.Maql).HasColumnName("maql");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasMaxLength(50);

                entity.Property(e => e.Matk).HasColumnName("matk");

                entity.Property(e => e.Sdt).HasColumnName("sdt");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Matk)
                    .HasName("PK__TAIKHOAN__7A217E168FE6A2E5");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Matk).HasColumnName("matk");

                entity.Property(e => e.Cvu)
                    .IsRequired()
                    .HasColumnName("cvu")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Tendangnhap)
                    .IsRequired()
                    .HasColumnName("tendangnhap")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thenoitru>(entity =>
            {
                entity.HasKey(e => e.Mathe)
                    .HasName("PK__THENOITR__148A03545A3B1202");

                entity.ToTable("THENOITRU");

                entity.Property(e => e.Mathe).HasColumnName("mathe");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasMaxLength(50);

                entity.Property(e => e.Lop)
                    .IsRequired()
                    .HasColumnName("lop")
                    .HasMaxLength(30);

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Toanha>(entity =>
            {
                entity.HasKey(e => e.Matoa)
                    .HasName("PK__TOANHA__1489C457708234FA");

                entity.ToTable("TOANHA");

                entity.Property(e => e.Matoa).HasColumnName("matoa");

                entity.Property(e => e.Tentoa)
                    .IsRequired()
                    .HasColumnName("tentoa")
                    .HasMaxLength(30);

                entity.Property(e => e.Vitri)
                    .HasColumnName("vitri")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__CB9A1CFF83368480");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200);

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
