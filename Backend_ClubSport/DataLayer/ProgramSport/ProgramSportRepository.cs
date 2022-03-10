using ClubSport.Domain.ProgramSport;
using Contracts.ProgramSport;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ProgramSport
{
 public   class ProgramSportRepository : BaseRepository<ClubSport.Domain.ProgramSport.ProgramSport>, IProgramSportRepository
    {
        public ProgramSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
      

    }
}
