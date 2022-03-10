using Esport= ClubSport.Domain.EventSport;
using Fsport = ClubSport.Domain.FieldSport;
using Hsport = ClubSport.Domain.HallSport;
using MMember = ClubSport.Domain.Member;
using Msport = ClubSport.Domain.MemberSport;
using Psport = ClubSport.Domain.ProgramSport;
using Rsport = ClubSport.Domain.RoleAccess;
using Ssport = ClubSport.Domain.ServicesSport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ClubSport.Domain.Member;
namespace DataLayer.Common
{
    public class ClubSportContext:DbContext
    {
        public ClubSportContext
      (Microsoft.EntityFrameworkCore.DbContextOptions<ClubSportContext> options) : base(options)
        {
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = false;
            Database.EnsureCreated();
        }
        public ClubSportContext()
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<MMember.Member> tbl_Member { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Msport.MemberSport> tbl_MemberSport { get; set; }
       // public Microsoft.EntityFrameworkCore.DbSet<Rsport.RoleAccess> tbl_RoleAccess { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Fsport.FieldSport> tbl_FieldSport { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Hsport.HallSport> tbl_HallSport { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Psport.ProgramSport> tbl_ProgramSport { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Esport.EventSport> tbl_EventSport { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Ssport.ServicesSport> tbl_ServicesSport { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Domain.User> Table_Users{ get; set; }
        public bool AutomaticMigrationsEnabled { get; }
        public bool AutomaticMigrationDataLossAllowed { get; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataLayer.EventSport.EventSportConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.HallSport.HallSportConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.Member.MemberConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.MemberSport.MemberSportConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.FieldSport.FieldSportConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.ProgramSport.ProgramSportConfig());
          
          //  modelBuilder.ApplyConfiguration(new DataLayer.RoleAccess.RoleAccessConfig());
            modelBuilder.ApplyConfiguration(new DataLayer.ServicesSport.ServicesSportConfig());

            base.OnModelCreating(modelBuilder);
        }


    }
}
