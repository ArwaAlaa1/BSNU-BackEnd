using BSNU.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Data.Configrations
{
    internal class ProgramtabelConfigration : IEntityTypeConfiguration<Programtabel>
    {
        public void Configure(EntityTypeBuilder<Programtabel> P)
        {
            // Make all properties required
            P.Property(p => p.CreditsHours)
                 .IsRequired();

            P.Property(p => p.ProgramId)
                 .IsRequired();
        }
    }
}
