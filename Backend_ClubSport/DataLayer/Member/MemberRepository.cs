using Contracts.Member;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Member
{
   public class MemberRepository : BaseRepository<ClubSport.Domain.Member.Member>, IMemberRepository
    {
        
        public MemberRepository(ClubSportContext dbContext) : base(dbContext)
        {

        }
    }
}
