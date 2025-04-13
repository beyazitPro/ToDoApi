using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAppEntities;

namespace TodoAppDataAccess
{
    public class TodoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BEYSO;Database=TodoDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.UserName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Email)
                       .IsRequired()
                       .HasMaxLength(50);

                entity.HasMany(u => u.ToDos)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId)
                      .IsRequired(false);                
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.Property(u => u.title)
                       .IsRequired()
                       .HasMaxLength(50);

                entity.Property(u=> u.description)
                       .IsRequired()
                       .HasMaxLength(100);

                entity.Property(u => u.isCompleted)
                       .IsRequired();

            });
        }
        public DbSet<TodoItem> Todo { get; set; }
        public DbSet<User> users { get; set; }
    }
}
