using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.RoleAccess
{
    internal class RoleAccessConfig : IEntityTypeConfiguration<ClubSport.Domain.RoleAccess.RoleAccess>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.RoleAccess.RoleAccess> builder)
        {
            builder.ToTable("Table_RoleAccesss");

            //builder
            //     .HasOne(a => a.E_Sport)
            //    .WithOne(b => b.R_Access).OnDelete(DeleteBehavior.SetNull)
            //    .HasForeignKey<ClubSport.Domain.EventSport.EventSport>(b => b.R_AccessRef);
        }
    }
}
