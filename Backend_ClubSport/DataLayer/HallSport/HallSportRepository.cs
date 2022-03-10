using Contracts.Common;
using Contracts.HallSport;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.HallSport
{
  public  class HallSportRepository : BaseRepository<ClubSport.Domain.HallSport.HallSport>,IHallSportRepository
    {
      
        public HallSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
       


    }
}
