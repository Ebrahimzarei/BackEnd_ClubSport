using ClubSport.Domain;
using ClubSport.Domain.EventSport;
using ClubSport.Domain.FieldSport;
using ClubSport.Domain.HallSport;
using ClubSport.Domain.Member;
using ClubSport.Domain.MemberSport;
using ClubSport.Domain.ProgramSport;
using ClubSport.Domain.RoleAccess;
using ClubSport.Domain.ServicesSport;

namespace Models
{
	public class Application : BaseEntity
	{
		public Application()  
		{
		}

      

	 
		public System.Collections.Generic.IList<EventSport> ApplicationEventSport { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList<FieldSport> ApplicationFieldSport { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList<HallSport> ApplicationHallSport { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList<Member> ApplicationMember { get; set; }
		// **********
		public System.Collections.Generic.IList<MemberSport> ApplicationMemberSport { get; set; }

		public System.Collections.Generic.IList<ProgramSport> ApplicationProgramSport { get; set; }
		//public System.Collections.Generic.IList<RoleAccess> ApplicationRoleAccess { get; set; }
		public System.Collections.Generic.IList<ServicesSport> ApplicationServicesSport { get; set; }
	}
}
