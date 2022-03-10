using Contracts.FieldSport;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.FieldSport
{
 public   class FieldSportRepository : BaseRepository<ClubSport.Domain.FieldSport.FieldSport>, IFieldSportRepository
    {
        public FieldSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
    }
}
