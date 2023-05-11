using JWT_test.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_test.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentSubject>(entity =>
            //{
            //    entity.ToTable("StudentSubject");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id)
            //        .ValueGeneratedOnAdd()
            //        .IsRequired();
            //    entity.HasOne<Subject>()
            //        .WithMany()
            //        .HasForeignKey(p => p.SubjectId);
            //    entity.HasOne<Student>()
            //        .WithMany()
            //        .HasForeignKey(p => p.StudentId);
            //});
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Students)
                .UsingEntity<StudentSubject>(
                    r => r.HasOne(e => e.Subject).WithMany(e => e.StudentSubjects).HasForeignKey(e => e.SubjectId),
                    l => l.HasOne(e => e.Student).WithMany(e => e.StudentSubjects).HasForeignKey(e => e.StudentId));
            //modelBuilder.Entity<Student>().HasMany(e => e.StudentSubjects).WithOne(e => e.Student).HasForeignKey(e => e.StudentId);
            //modelBuilder.Entity<Subject>().HasMany(e => e.StudentSubjects).WithOne(e => e.Subject).HasForeignKey(e => e.SubjectId);

        }

    }
}
