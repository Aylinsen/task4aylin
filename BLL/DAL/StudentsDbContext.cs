using Microsoft.EntityFrameworkCore;
using BLL.DAL.Entities;

namespace BLL.DAL
{
    public class StudentsDbContext : DbContext
    {
        // DbSet ile veritabanı tablolarını tanımlarız. Örneğin Students tablosu.
        public DbSet<Student> Students { get; set; }

        // Bu metod veritabanı bağlantı ayarlarını yapılandırır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // PostgreSQL bağlantı dizesini burada belirtiyoruz.
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StudentsDB;Username=postgres;Password=1234");
        }

        // Veritabanı tablolarını yapılandırmak için kullanılabilir. (İsteğe bağlı)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Örneğin, Student tablosunda Name sütununun maksimum uzunluğunu ayarlayabiliriz.
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(50);
        }
        
        public void SeedData()
        {
            if (!this.Students.Any())
            {
                this.Students.AddRange(
                    new Student { Name = "John", Surname = "Doe", BirthDate = new DateTime(1995, 5, 12), GPA = 3.5M },
                    new Student { Name = "Jane", Surname = "Smith", BirthDate = new DateTime(1998, 7, 24), GPA = 3.8M }
                );
                this.SaveChanges();
            }
        }

    }
}