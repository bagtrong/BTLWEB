using thuchanh_web_lan1_ngay15_2.Models;
namespace thuchanh_web_lan1_ngay15_2.Repository
{
    public class CLoaiRepository : ILoaiSpRepository
    {
        private readonly QlbanVaLiContext _context;
        public CLoaiRepository(QlbanVaLiContext context)
        {
            _context = context;
        }

        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maloaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloaiSp)
        {
            return _context.TLoaiSps.Find(maloaiSp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

    }
}
