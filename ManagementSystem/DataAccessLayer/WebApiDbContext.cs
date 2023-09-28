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
            modelBuilder.Entity<ClassEntity>()
        .HasOne(c => c.Course)               // ClassEntity has one Course
        .WithMany(c => c.Class)           // CourseEntity has many Classes
        .HasForeignKey(c => c.Id)          // Foreign key in ClassEntity
        .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior if needed

            modelBuilder.Entity<CourseEntity>()
        .HasKey(c => c.Id); // Define the primary key for CourseEntity

            // Define the relationship with students
            modelBuilder.Entity<CourseEntity>()
                .HasMany(c => c.Students)           // CourseEntity has many Students
                .WithOne(s => s.Course)             // StudentEntity has one Course
                .HasForeignKey(s => s.Id)     // Foreign key in StudentEntity
                .OnDelete(DeleteBehavior.Restrict);
            // Define the primary key for CourseEntity
            // For ClassEntity to FacilitatorEntity relationship
            modelBuilder.Entity<ClassEntity>()
                .HasOne(c => c.Facilitator)         // ClassEntity has one Facilitator
                .WithMany(f => f.Class)           // FacilitatorEntity has many Classes
                .HasForeignKey(c => c.FacilitatorId) // Foreign key in ClassEntity
                .OnDelete(DeleteBehavior.Restrict); 
                    modelBuilder.Entity<ClassEntity>(entity => { entity.HasKey(p => p.ClassId); });
     

            base.OnModelCreating(modelBuilder);
        }
        //Db Set entities
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<FacilitatorEntity> Facilitators { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        
    }
}
