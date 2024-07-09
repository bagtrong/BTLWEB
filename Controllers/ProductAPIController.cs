using Microsoft.AspNetCore.Mvc;
using thuchanh_web_lan1_ngay15_2.Models;
using thuchanh_web_lan1_ngay15_2.Models.Product_pModels;

namespace thuchanh_web_lan1_ngay15_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductAPIController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]

        public IEnumerable<Product> GetAllProducts()
        {
            var product = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat,
                           }).ToList();
            return product;
        }




        [HttpGet("{maLoai}")]

        //public IEnumerable<Product> GetProductsByCategory(string maLoai)
        //{
        //    var products = (from p in db.TDanhMucSps
        //                    where p.MaLoai == maLoai
        //                    select new Product
        //                    {
        //                        MaSp = p.MaSp,
        //                        TenSp = p.TenSp,
        //                        MaLoai = p.MaLoai,
        //                        AnhDaiDien = p.AnhDaiDien,
        //                        GiaNhoNhat = p.GiaNhoNhat
        //                    }).ToList();
        //    return products;
        //}

        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {
            var products = (from p in db.TDanhMucSps
                            where p.MaLoai == maloai
                            select new Product
                            {
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat,
                            }).ToList();
            return products;
        }



    }
}
