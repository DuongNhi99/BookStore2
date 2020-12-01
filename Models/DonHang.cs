using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DonHang
    {
        [Key]
        public int MaDH { get; set; }

        //public int? IDUser { get; set; }
        public virtual User User { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [DisplayName("Ngày đặt hàng")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy }",
            ApplyFormatInEditMode = true)]
        public DateTime NgayDat { get; set; }

        [DisplayName("Giá vận chuyển")]
        public int GiaVanChuyen { get; set; }

        [StringLength(20)]
        [DisplayName("Mã Khuyến mãi")]
        public string KhuyenMai { get; set; }
       
        public float TongTien { get; set; }

        [StringLength(30)]
        public string TinhTrangDonHang { get; set; }

        [ForeignKey("ThanhToan")]
        public int? MaTT { get; set; }
        public virtual ThanhToan ThanhToan { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

    }
}