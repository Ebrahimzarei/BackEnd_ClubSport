using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClubSport.Domain.HallSport
{
    //سالن ورزشی
    public class HallSport: BaseEntity
    {
        public HallSport()
        {

        }
        public int HallId { get; set; }
        public string Name { get; set; }
         public ClubSport.Domain.EventSport.EventSport E_Sport { get; set; }
        public ClubSport.Domain.ServicesSport.ServicesSport S_Sport { get; set; }
          public ClubSport.Domain.ProgramSport.ProgramSport P_Sport { get; set; }
        [ForeignKey("MemberSportRef")]
        public virtual ClubSport.Domain.MemberSport.MemberSport M_Sport { get; set; }
        public int MemberSportRef { get; set; }
    }
}
