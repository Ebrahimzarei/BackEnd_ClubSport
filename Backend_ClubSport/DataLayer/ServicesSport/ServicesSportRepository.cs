using ClubSport.Domain.ServicesSport;
 
using Contracts.ServicesSport;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ServicesSport
{
  public  class ServicesSportRepository : BaseRepository<ClubSport.Domain.ServicesSport.ServicesSport>, IServicesSportRepositroy
    {
        public ServicesSportRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
    }
}
