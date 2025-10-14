using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Models
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {
        }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<NoteModel> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().ToTable("Item");
            modelBuilder.Entity<NoteModel>().ToTable("Note")
                .HasOne(n=>n.Item)
                .WithMany(i=>i.Notes)
                .HasForeignKey(n=>n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
