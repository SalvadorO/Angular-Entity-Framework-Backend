using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }


        public DbSet<CookingVideo> CookingVideos { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
