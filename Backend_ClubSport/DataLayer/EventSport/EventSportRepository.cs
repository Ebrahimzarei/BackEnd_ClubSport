using Contracts.EventSport;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EventSport
{
 public  class EventSportRepository : BaseRepository<ClubSport.Domain.EventSport.EventSport>, IEventSportRepository
    {
    
        public EventSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
    }
}
