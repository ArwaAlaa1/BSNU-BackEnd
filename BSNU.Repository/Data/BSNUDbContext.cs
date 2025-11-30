using BSNU.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Data
{
   public class BSNUDbContext :IdentityDbContext<AppUser>
    {
        public BSNUDbContext(DbContextOptions<BSNUDbContext> options)
            : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProgramEntite>()
        .HasOne(p => p.User)
        .WithOne(u => u.Program)
        .HasForeignKey<ProgramEntite>(p => p.UserId);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<ProgramEntite> Programs { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<ProgramEntite> Program { get; set; }

        public DbSet<Programtabel> Programtabels { get; set; }


    }
}
