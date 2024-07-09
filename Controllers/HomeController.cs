using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using thuchanh_web_lan1_ngay15_2.Models;
using X.PagedList;
using Microsoft.AspNetCore.Session;
namespace thuchanh_web_lan1_ngay15_2.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null | page <= 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);

            PagedList<TDanhMucSp> listsp = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(listsp);
        }
        //public IActionResult ChiTietSanPham()
        //{

        //} 
        public IActionResult SanPhamTheoLoai(String maLoai, int? page)
        {
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            int pageSize = 8;
            var lstsanpham = db.TDanhMucSps.Where(x => x.MaLoai == maLoai).AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            ViewBag.maLoai = maLoai;


            //List<TDanhMucSp> lstSanPham = db.TDanhMucSps.Where(x => x.MaLoai == maLoai).ToList();
            return View(lst);
        }
        public IActionResult ChiTietSanPham(String maLoai, int? page)
        {

            return View();
        }
        public IActionResult SanPhamDetail(String masp)
        {
            var product = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var lstAnhSanPham = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
            ViewBag.lstAnhSanPham = lstAnhSanPham;
            return View(product);
        }
        //public IActionResult index1()
        //{
        //    return View();
        //}

        //public IActionResult Login(TUser User)
        //{
        //    var user2= db.TUsers.Where(n=>n.Username)
        //    Session
        //}
        public IActionResult Privacy()
        {


            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //  QlbanVaLiContext db = new QlbanVaLiContext();
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Login(TUser user)
        //{
        //    //using (DB_Entity db = new DB_Entity())
        //    //{
        //    //    var usr = db.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
        //    //    if (usr != null)
        //    //    {
        //    //        Session["idUser"] = usr.idUser.ToString();
        //    //        Session["UserName"] = usr.UserName.ToString();
        //    //        return RedirectToAction("Index");

        //    //    }
        //    //    else
        //    //    {
        //    //        ModelState.AddModelError("", "Username or Password is wrong")
        //    //    }

        //    //}

        //    return View();

        //}
        [Route("login")]



        public IActionResult Login()
        {
            // if(HttpContext.Session.GetString("Username"==null))
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
       // [HttpPost]

        //public IActionResult Login(TUser user)
        //{
        //    //  if(HttpContext.Session.GetString)
        //    if (HttpContext.Session.GetString("Username") == null)
        //    {
        //        var obj = db.TUsers.Where(x => x.Username == user.Username &&
        //        x.Password == user.Password).FirstOrDefault();
        //        if (obj != null)
        //        {
        //            HttpContext.Session.SetString("UserName", obj.Username.ToString());
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View();



        //}

    }


}

