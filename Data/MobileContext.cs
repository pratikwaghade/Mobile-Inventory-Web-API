using Microsoft.EntityFrameworkCore;
using Mobile_Inventory_Web_API.Model;

namespace Mobile_Inventory_Web_API.Data
{
    public class MobileContext : DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            string connnectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = MobileDB; TrustServerCertificate = True; Integrated Security = True";
            optionsBuilder.UseSqlServer(connnectionString);


        }
    }
}
