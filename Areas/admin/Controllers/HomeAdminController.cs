using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using thuchanh_web_lan1_ngay15_2.Models;
using X.PagedList;

namespace thuchanh_web_lan1_ngay15_2.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DanhMucSanPham") ]
        public IActionResult DanhMucSanPham(int? page)
        {

            //var lstSanPham = db.TDanhMucSps.ToList();
            //return View(lstSanPham);
            int pageSize = 8;
            int pageNumber = page == null | page <= 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);

            PagedList<TDanhMucSp> listsp = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(listsp);
        }

        [Route("XoaSp")]
        [HttpGet]
        public IActionResult XoaSanPham()
        {

            return View();
        }
      //[Route("ThemSanPham")]
        //[HttpGet]



        //public IActionResult ThemSanPham()
        //{
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChaLieu", "ChatLieu");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaHangSx", "HangSx");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaNuoc", "TenNuoc");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaLoai", "Loai");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaDt", "TenLoai");
        //    return View();
        //}
        //[Route("ThemSanPham")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult ThemSanPham(TDanhMucSp sanPham)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Add(sanPham);
        //        db.SaveChanges();
        //        return RedirectToAction("DanhMucSanPham");

        //    }
        //    return View(sanPham);
        //}*@




        [Route("create")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            return View();
        }
        [Route("create")]
        [HttpPost]
        public IActionResult ThemSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                //RedirectToAction("Index");
            }
           
            return View(sanPham);
        }
        [Route("HoaDonBan")]
        public IActionResult HoaDonBan()
        {

            //var lstSanPham = db.TDanhMucSps.ToList();
            //return View(lstSanPham);
           var listHD = db.THoaDonBans.ToList();
            return View(listHD);
        }
        [Route("ChiTietHDB")]
        public IActionResult ChiTietHDB()
        {

            //var lstSanPham = db.TDanhMucSps.ToList();
            //return View(lstSanPham);
            var listHD = db.TChiTietHdbs.ToList();
            return View(listHD);
        }
        [Route("ChiTietSP")]
        public IActionResult ChiTietSP()
        {

            //var lstSanPham = db.TDanhMucSps.ToList();
            //return View(lstSanPham);
            var listHD = db.TChiTietSanPhams.ToList();
            return View(listHD);
        }
        [Route("ThemChiTietDD")]
        [HttpGet]
        public IActionResult ThemChiTietDD()
        {
            return View();
        }
        [Route("ThemChiTietDD")]
        [HttpPost]
        public IActionResult ThemChiTietDD(TChiTietHdb sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TChiTietHdbs.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietHDB", "HomeAdmin");
                //RedirectToAction("Index");
            }

            return View(sanPham);
        }
        [Route("ThemDonDat")]
        [HttpGet]
        public IActionResult ThemDonDat()
        {
            return View();
        }
        [Route("ThemDonDat")]
        [HttpPost]
        public IActionResult ThemDonDat(THoaDonBan sanPham)
        {
            if (ModelState.IsValid)
            {
                db.THoaDonBans.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("HoaDonBan", "HomeAdmin");
                //RedirectToAction("Index");
            }

            return View(sanPham);
        }
        [Route("ThemChiTietSP")]
        [HttpGet]
        public IActionResult ThemChiTietSP()
        {
            return View();
        }
        [Route("ThemChiTietSP")]
        [HttpPost]
        public IActionResult ThemChiTietSP(TChiTietSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TChiTietSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietSP", "HomeAdmin");
                //RedirectToAction("Index");
            }

            return View(sanPham);
        }


        [Route("SuaChiTietHD")]
        [HttpGet]
        public IActionResult SuaChiTietHD(string maSp)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            var sanpham = db.TChiTietHdbs.Find(maSp);
            return View(sanpham);
        }
        [Route("SuaChiTietHD")]
        [HttpPost]
        public IActionResult SuaSanPham(TChiTietHdb sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        [Route("SuaHDB")]
        [HttpGet]
        public IActionResult SuaHDB(string maSp)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            var sanpham = db.THoaDonBans.Find(maSp);
            return View(sanpham);
        }
        [Route("SuaHDB")]
        [HttpPost]
        public IActionResult SuaHDB(THoaDonBan sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }





        [Route("suaSP")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSp)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");

            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            var sanpham = db.TDanhMucSps.Find(maSp);
            return View(sanpham);
        }
        [Route("suaSP")]
        [HttpPost]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }
        //public IActionResult SuaSanPham(TDanhMucSp sanPham)
        //{

        //}
        //public IActionResult SuaSanPham(string maSanPham)
        //{
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
        //    ViewBag.MaHangSx = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");

        //    return View()
        //}
        [Route("Detail")]
        [HttpGet]
        public IActionResult Detail(string? maSp)
        {
            var sanpham = db.TChiTietSanPhams.Find(maSp);
            
            return View(sanpham);
        }
        [Route("XoaSanPham")]
        [HttpGet]

        public IActionResult XoaSanPham(string maSp)
        {
            TempData["Message"] = "";
            var listChiTiet = db.TChiTietSanPhams.Where(x => x.MaSp == maSp);
            foreach (var item in listChiTiet)
            {
                if (db.TChiTietHdbs.Where(x => x.MaChiTietSp == item.MaChiTietSp) != null)
                {
                    TempData["Message"] = "Không xóa được sản phẩm này";
                    return RedirectToAction("DanhMucSanPham");
                }
            }
            var listAnh = db.TAnhSps.Where(x => x.MaSp == maSp);
            if (listAnh != null) db.RemoveRange(listAnh);
            if (listChiTiet != null) db.RemoveRange(listChiTiet);
            db.Remove(db.TDanhMucSps.Find(maSp));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhMucSanPham");
        }

       
    }
}



