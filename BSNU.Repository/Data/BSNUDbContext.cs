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
    public class BSNUDbContext : IdentityDbContext<AppUser>
    {
        public BSNUDbContext(DbContextOptions<BSNUDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<News>()
         .HasOne(n => n.Category)
         .WithMany(c => c.News)
         .HasForeignKey(n => n.CategoryId)
         .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Sector> Sectors => Set<Sector>();
        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Programs> Programs => Set<Programs>();
        public DbSet<StaffMember> StaffMembers => Set<StaffMember>();
        public DbSet<Category> Categories { get; set; }
        public DbSet<Banner> Banners { get; set; }

        public DbSet<AdmissionRule> AdmissionRules { get; set; }

        public DbSet<TuitionFees> TuitionFee { get; set; }

        public DbSet<AdmissionDocument> AdmissionDocuments { get; set; }
    }
}
