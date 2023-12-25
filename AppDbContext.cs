namespace ez3
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<UtilityService> UtilityServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R71F0DV\\SQLEXPRESS;Database=ez3;Trusted_Connection=True;");

        }
    }


}
