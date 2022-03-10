using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Member
{
    internal class MemberConfig : IEntityTypeConfiguration<ClubSport.Domain.Member.Member>
    {
        public void Configure(EntityTypeBuilder<ClubSport.Domain.Member.Member> builder)
        {
            builder.ToTable("Table_Members");
           // builder
           //.HasOne(a => a.R_Access)
           //.WithOne(b => b.M_Member)
           //.OnDelete(DeleteBehavior.SetNull)
           //.HasForeignKey<ClubSport.Domain.RoleAccess.RoleAccess>(b => b.MemberRef);
            builder.HasData(
        new ClubSport.Domain.Member.Member
        {
            Id=1,
            Memberid=1,
          FatherName="Reaz",
          FullName="EbrahimZarei",
          Natinalcode = "2289567482",
          Password="1234567890",
          Role="Admin",
          UserName="Ebrahim"
        }
        );

        }
    }
}
