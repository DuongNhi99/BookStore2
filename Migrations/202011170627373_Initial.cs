namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonHangs",
                c => new
                    {
                        MaDH = c.Int(nullable: false),
                        MaSach = c.Int(nullable: false),
                        SoLuong = c.Int(),
                        TongTien = c.String(),
                    })
                .PrimaryKey(t => new { t.MaDH, t.MaSach })
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .ForeignKey("dbo.DonHangs", t => t.MaDH, cascadeDelete: true)
                .Index(t => t.MaDH)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(nullable: false, maxLength: 50),
                        TacGia = c.String(nullable: false, maxLength: 50),
                        NXB = c.String(nullable: false, maxLength: 50),
                        Gia = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        HinhAnh = c.String(),
                        MaLoai = c.Int(),
                        NCC = c.Int(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.Loais", t => t.MaLoai)
                .ForeignKey("dbo.NhaCungCaps", t => t.NCC)
                .Index(t => t.MaLoai)
                .Index(t => t.NCC);
            
            CreateTable(
                "dbo.Loais",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNCC = c.Int(nullable: false, identity: true),
                        TenNCC = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.DanhGias",
                c => new
                    {
                        MaGY = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 30),
                        SDT = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaGY);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        MaDH = c.Int(nullable: false, identity: true),
                        SDT = c.String(maxLength: 20),
                        NgayDat = c.DateTime(nullable: false),
                        GiaVanChuyen = c.Int(nullable: false),
                        KhuyenMai = c.String(maxLength: 20),
                        TongTien = c.Single(nullable: false),
                        TinhTrangDonHang = c.String(maxLength: 30),
                        MaTT = c.Int(),
                        User_IDUser = c.Int(),
                    })
                .PrimaryKey(t => t.MaDH)
                .ForeignKey("dbo.ThanhToans", t => t.MaTT)
                .ForeignKey("dbo.Users", t => t.User_IDUser)
                .Index(t => t.MaTT)
                .Index(t => t.User_IDUser);
            
            CreateTable(
                "dbo.ThanhToans",
                c => new
                    {
                        MaTT = c.Int(nullable: false, identity: true),
                        LoaiTT = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.MaTT);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 30),
                        SDT = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        MaQuyen = c.Int(),
                    })
                .PrimaryKey(t => t.IDUser)
                .ForeignKey("dbo.PhanQuyens", t => t.MaQuyen)
                .Index(t => t.MaQuyen);
            
            CreateTable(
                "dbo.PhanQuyens",
                c => new
                    {
                        MaQuyen = c.Int(nullable: false, identity: true),
                        LoaiQuyen = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.MaQuyen);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "User_IDUser", "dbo.Users");
            DropForeignKey("dbo.Users", "MaQuyen", "dbo.PhanQuyens");
            DropForeignKey("dbo.DonHangs", "MaTT", "dbo.ThanhToans");
            DropForeignKey("dbo.ChiTietDonHangs", "MaDH", "dbo.DonHangs");
            DropForeignKey("dbo.Saches", "NCC", "dbo.NhaCungCaps");
            DropForeignKey("dbo.Saches", "MaLoai", "dbo.Loais");
            DropForeignKey("dbo.ChiTietDonHangs", "MaSach", "dbo.Saches");
            DropIndex("dbo.Users", new[] { "MaQuyen" });
            DropIndex("dbo.DonHangs", new[] { "User_IDUser" });
            DropIndex("dbo.DonHangs", new[] { "MaTT" });
            DropIndex("dbo.Saches", new[] { "NCC" });
            DropIndex("dbo.Saches", new[] { "MaLoai" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "MaSach" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "MaDH" });
            DropTable("dbo.PhanQuyens");
            DropTable("dbo.Users");
            DropTable("dbo.ThanhToans");
            DropTable("dbo.DonHangs");
            DropTable("dbo.DanhGias");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.Loais");
            DropTable("dbo.Saches");
            DropTable("dbo.ChiTietDonHangs");
        }
    }
}
