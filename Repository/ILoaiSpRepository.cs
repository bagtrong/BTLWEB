using thuchanh_web_lan1_ngay15_2.Models;
namespace thuchanh_web_lan1_ngay15_2.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(String maloaiSp);

        TLoaiSp GetLoaiSp(String maloaiSp);
       // TLoaiSp GetLoaiSp

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
