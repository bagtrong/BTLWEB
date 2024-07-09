using Microsoft.AspNetCore.Mvc;
using thuchanh_web_lan1_ngay15_2.Models;

namespace thuchanh_web_lan1_ngay15_2.Controllers
{
    public class LoginController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Login");

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {

                var obj = db.TUsers.Where(x => x.Username == user.Username && x.Password == user.Password && x.LoaiUser==1).FirstOrDefault();
                
                var obj2 = db.TUsers.Where(x => x.Username == user.Username && x.Password == user.Password && x.LoaiUser == 2).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("UserName", obj.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
                if (obj2 != null)
                {
                    HttpContext.Session.SetString("UserName", obj2.Username.ToString());
                    return RedirectToAction("danhmucsanpham", "admin");
                }
            }
            return View();
        }

    }
   
}
