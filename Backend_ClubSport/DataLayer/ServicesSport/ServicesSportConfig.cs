using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SSPort= ClubSport.Domain.ServicesSport;

namespace DataLayer.ServicesSport
{
    internal class ServicesSportConfig : IEntityTypeConfiguration<SSPort.ServicesSport>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SSPort.ServicesSport> builder)
        {
            builder.ToTable("Table_ServicesSports");


        }
    }
}
