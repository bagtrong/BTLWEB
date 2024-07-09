using System;
using System.Collections.Generic;

namespace thuchanh_web_lan1_ngay15_2.Models;

public partial class THangSx
{
    public string MaHangSx { get; set; } = null!;

    public string? HangSx { get; set; }

    public string? MaNuocThuongHieu { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; } = new List<TDanhMucSp>();
}
