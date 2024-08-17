using Lesson_8_EF.Models.Entities.Concrets;
using Microsoft.EntityFrameworkCore;

namespace Lesson_8_EF.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.GroupId);

        base.OnModelCreating(modelBuilder);
    }


    // Tables
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Mark> Marks { get; set; }
}
