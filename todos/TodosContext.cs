using Microsoft.EntityFrameworkCore;
using todos.Models;

namespace todos
{
    public class TodosContext: DbContext
    {

        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=asptodos;User Id=phani; Timeout = 15;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Todo>(todo => { todo.ToTable("todos"); });

            base.OnModelCreating(modelBuilder);
        }

    }
}
