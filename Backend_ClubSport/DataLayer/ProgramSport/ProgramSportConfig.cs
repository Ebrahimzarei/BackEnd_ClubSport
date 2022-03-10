using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ProgramSport
{
    internal class ProgramSportConfig : IEntityTypeConfiguration<ClubSport.Domain.ProgramSport.ProgramSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.ProgramSport.ProgramSport> builder)
        {
            builder.ToTable("Table_ProgramSports");
            builder
                   .HasOne(a => a.E_Sport)
                   .WithOne(b => b.P_Sport)
              
                   
                 
                   .HasForeignKey<ClubSport.Domain.EventSport.EventSport>(b => b.ProgramSportRef).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
          
            builder.Property(c => c.DaysOfYear).HasConversion<int>();
      
        }
    }
}
