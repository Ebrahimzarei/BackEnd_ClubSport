using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EventSport
{
    internal class EventSportConfig : IEntityTypeConfiguration<ClubSport.Domain.EventSport.EventSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.EventSport.EventSport> builder)
        {
    
            builder.ToTable("Table_EventSports");
            builder
                   .HasOne(a => a.P_Sport)
                   .WithOne(b => b.E_Sport)
                 

                   .HasForeignKey<ClubSport.Domain.EventSport.EventSport>(b => b.ProgramSportRef).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            //    builder.Property(c => c.ProgramSportRef).IsRequired();

        }
    }
}
