using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext (DbContextOptions<KanbanContext> options)
            : base(options)
        {
        }

        public DbSet<Kanban.Models.Card> Card { get; set; } = default!;
        public DbSet<Kanban.Models.Container> Container { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().HasData(new { Id = 1, Title = "Todo" }, new { Id = 2, Title = "In Progress" }, new { Id = 3, Title = "Done" } );
        }
    }
}