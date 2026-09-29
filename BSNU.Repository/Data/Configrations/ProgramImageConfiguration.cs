using BSNU.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Repository.Data.Configrations
{
    public class ProgramImageConfiguration : IEntityTypeConfiguration<ProgramImage>
    {
        public void Configure(EntityTypeBuilder<ProgramImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.Program)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
