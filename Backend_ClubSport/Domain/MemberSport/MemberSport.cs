using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClubSport.Domain.MemberSport
{
  public  class MemberSport : BaseEntity
    {
        public MemberSport()
        {

        }
      
        public int MemberId { get; set; }
        public int Ncode { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        //
     //   public virtual ClubSport.Domain.RoleAccess.RoleAccess R_Access { get; set; }
         public virtual ClubSport.Domain.ProgramSport.ProgramSport P_Sport { get; set; }
        [ForeignKey("HallSportRef")]
        public virtual ClubSport.Domain.HallSport.HallSport H_Sport { get; set; }
        public int HallSportRef { get; set; }
    }
}
