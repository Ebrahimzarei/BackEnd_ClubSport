using Contracts.MemberSport;
using DataLayer.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MemberSport
{
 public   class MemberSportRepository : BaseRepository<ClubSport.Domain.MemberSport.MemberSport>, IMemberSportRepository
    {
        public MemberSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
       
    }
}
