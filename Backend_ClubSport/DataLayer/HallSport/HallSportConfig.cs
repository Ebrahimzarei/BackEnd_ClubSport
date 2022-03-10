using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.HallSport
{
    internal class HallSportConfig : IEntityTypeConfiguration<ClubSport.Domain.HallSport.HallSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.HallSport.HallSport> builder)
        {
            builder.ToTable("Table_HallSports");

           // builder.HasOne(s => s.M_Sport) // Mark Address property optional in Student entity
           //.WithOne(ad => ad.H_Sport)
           //.HasForeignKey<ClubSport.Domain.HallSport.HallSport>(c => c.MemberSportRef).OnDelete(DeleteBehavior.SetNull).IsRequired(false)
           //;


            builder
       .HasOne(a => a.E_Sport)
       .WithOne(b => b.H_Sport).HasForeignKey<ClubSport.Domain.EventSport.EventSport>(b => b.HallSportRef)
       .OnDelete(DeleteBehavior.NoAction).IsRequired(false)
       ;

            builder
      .HasOne(a => a.S_Sport)
      .WithOne(b => b.H_sport)
      .OnDelete(DeleteBehavior.NoAction)
      .HasForeignKey<ClubSport.Domain.ServicesSport.ServicesSport>(b => b.HallSportRef);

            builder
     .HasOne(a => a.P_Sport)
     .WithOne(b => b.H_Sport)
     .OnDelete(DeleteBehavior.NoAction)
     .HasForeignKey<ClubSport.Domain.ProgramSport.ProgramSport>(b => b.HallSportRef);
        }
    }
}
