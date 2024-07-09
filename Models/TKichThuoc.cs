using System;
using System.Collections.Generic;

namespace thuchanh_web_lan1_ngay15_2.Models;

public partial class TKichThuoc
{
    public string MaKichThuoc { get; set; } = null!;

    public string? KichThuoc { get; set; }

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; } = new List<TChiTietSanPham>();
}
