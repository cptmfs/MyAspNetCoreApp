using Microsoft.EntityFrameworkCore;

namespace MyAspNetCoreApp.Web2.Models
{
    public class LessonDbContext:DbContext
    {
        public LessonDbContext(DbContextOptions<LessonDbContext> options):base(options)
        {

        }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
