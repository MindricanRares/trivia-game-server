using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasOne(p => p.Category)
                .WithMany(b => b.Questions)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("ForeignKey_Question_Category");

                 modelBuilder.Entity<Player>()
                .HasOne(p => p.Game)
                .WithMany(b => b.Players)
                .HasForeignKey(p => p.GameroomId)
                .HasConstraintName("ForeignKey_Player_Game");

                modelBuilder.Entity<CategoryGame>()
                .HasKey(cg => new { cg.GameId, cg.CategoryId });

                 modelBuilder.Entity<CategoryGame>()
                .HasOne(g => g.Game)
                .WithMany(b => b.CategoryGames)
                .HasForeignKey(bc => bc.GameId);

                 modelBuilder.Entity<CategoryGame>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.CategoryGames)
                .HasForeignKey(bc => bc.CategoryId);
        }


        public ApplicationContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}
