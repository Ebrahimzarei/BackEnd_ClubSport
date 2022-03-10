using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.FieldSport
{
    internal class FieldSportConfig : IEntityTypeConfiguration<ClubSport.Domain.FieldSport.FieldSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.FieldSport.FieldSport> builder)
        {
            builder.ToTable("Table_FieldSports");
          builder 
           .HasOne(a => a.E_Sport)
           .WithOne(b => b.F_Sport)
          
           .HasForeignKey< ClubSport.Domain.EventSport.EventSport>(b => b.FieldSportRef).OnDelete(DeleteBehavior.NoAction)
           .IsRequired(false)
           ;

            builder
     .HasOne(a => a.P_Sport)
     .WithOne(b => b.F_Sport)
   
     .HasForeignKey<ClubSport.Domain.ProgramSport.ProgramSport>(b => b.FieldSportRef).OnDelete(DeleteBehavior.NoAction)
      .IsRequired(false)
     ;

        }
    }
}
