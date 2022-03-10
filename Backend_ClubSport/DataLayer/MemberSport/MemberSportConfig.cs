using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MemberSport
{
    public class MemberSportConfig : IEntityTypeConfiguration<ClubSport.Domain.MemberSport.MemberSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.MemberSport.MemberSport> builder)
        {
            builder.ToTable("Table_MemberSports");
           
            builder 
         .HasOne(a => a.P_Sport)
         .WithOne(b => b.M_Sport)
         .HasForeignKey<ClubSport.Domain.ProgramSport.ProgramSport>(b => b.PMemberSportRef).IsRequired(false)
         .OnDelete(DeleteBehavior.NoAction)
      ;
            builder


                       .HasOne(a => a.H_Sport)
                       .WithOne(b => b.M_Sport)
                       .HasForeignKey<ClubSport.Domain.HallSport.HallSport>(b => b.MemberSportRef)
                       .OnDelete(DeleteBehavior.NoAction).IsRequired(false)

                       ;



        }
    }
}
