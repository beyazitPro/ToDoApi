using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAppEntities;

namespace TodoAppDataAccess
{
    public class TodoDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BEYSO;Database=TodoDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<TodoItem> Todo { get; set; }
    }
}
