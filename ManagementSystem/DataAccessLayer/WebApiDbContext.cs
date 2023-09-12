using ManagementSystem.BusinessLogicLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.DataAccessLayer
{
    public class WebApiDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connection = _configuration.GetConnectionString(@"Data Source=hermes;Initial Catalog=StudentManagement;Integrated Security=True;");
            optionsBuilder.UseSqlServer((@"Data Source=hermes;Initial Catalog=StudentManagement;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True"));
            base.OnConfiguring(optionsBuilder);
        }
        //Bind class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>(entity => { entity.HasKey(p => p.Id); });
            base.OnModelCreating(modelBuilder);
        }
        //Db Set entities
        public DbSet<CourseEntity> Courses { get; set; }
    }
}
