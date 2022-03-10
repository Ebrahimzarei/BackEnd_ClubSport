
using Contracts.RoleAccess;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.RoleAccess
{
    public class RoleAccessRepository : BaseRepository<ClubSport.Domain.RoleAccess.RoleAccess>, IRoleAccessRepositroy
    {
        public RoleAccessRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }

    }
}
