using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ApplicationUser> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeacherClass>()
                .HasKey(e => new { e.ClassId, e.TeacherId });

            base.OnModelCreating(builder);
        }
    }
}