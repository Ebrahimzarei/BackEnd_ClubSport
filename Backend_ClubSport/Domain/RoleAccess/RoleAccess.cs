 
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ClubSport.Domain;

namespace ClubSport.Domain.RoleAccess
{
  
 public   class RoleAccess : BaseEntity
    {

        public RoleAccess()
        {

        }
        public int RoleId { get; set; }

        public ClubSport.Domain.Enums.Roles Role { get; set; }
        public string NameRole { get; set; }
        //
          public ClubSport.Domain.EventSport.EventSport E_Sport { get; set; }
        [ForeignKey("MemberRef")]
        public ClubSport.Domain.Member.Member M_Member { get; set; }
        public int MemberRef { get; set; }

    
    }
}
