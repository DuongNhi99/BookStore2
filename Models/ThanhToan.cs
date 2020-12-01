using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ThanhToan
    {
        [Key]
        public int MaTT { get; set; }

        [DisplayName("Loại thanh toán")]
        [Required(ErrorMessage = "Nhập tên loại thanh toán")]
        [StringLength(30, ErrorMessage = "Tên loại không vượt quá 30 ký tự")]
        public string LoaiTT { get; set; }

        public ICollection<DonHang> DonHangs  { get; set; }

    }
}