using Microsoft.EntityFrameworkCore;

namespace thuchanh_web_lan1_ngay15_2.Models
{
    public class DB_Entity: DbContext
    {
        public DbSet<TUser> Users { get; set; }
    }
}
