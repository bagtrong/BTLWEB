using System;
using System.Collections.Generic;

namespace thuchanh_web_lan1_ngay15_2.Models;

public partial class TLoaiSp
{
    public string MaLoai { get; set; } = null!;

    public string? Loai { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; } = new List<TDanhMucSp>();
}
