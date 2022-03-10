using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Common
{
    public class ClubSportContextFactory : IDesignTimeDbContextFactory<ClubSportContext>
    {
        public ClubSportContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ClubSportContext>();
            builder.UseSqlServer(
                "Data Source=.;Initial Catalog=Backend_WebClubSportDb;Persist Security Info=True;MultipleActiveResultSets=True;User ID=ebrahim;Password=@110;Connect Timeout=40;Application Name=EntityFramework");

            return new ClubSportContext(builder.Options);
        }
        public ClubSportContextFactory()
        {

        }
    }
}
