using BSNU.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Data.Configrations
{
    internal class ProgramConfigrations : IEntityTypeConfiguration<ProgramEntite>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProgramEntite> P)
        {
            // Make all properties required
            P.Property(p => p.Name)
                 .IsRequired();

            P.Property(p => p.Mission)
                 .IsRequired();

            P.Property(p => p.Vision)
                 .IsRequired();

            P.Property(p => p.Goals)
                 .IsRequired();

            P.Property(p => p.Duration)
                 .IsRequired();

            P.Property(p => p.jopTitel)
                 .IsRequired();

            P.Property(p => p.CreditHour)
               .IsRequired();

            P.Property(p => p.AcadamicDegree)
                .IsRequired();

            P.Property(p => p.NumberOfStudents)
                .IsRequired();
      
            P.Property(p => p.UserId)
                .IsRequired();
        }
    }
}
