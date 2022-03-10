
using ClubSport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ClubSport.Domain;

namespace ClubSport.Domain.ProgramSport
{
    //برنامه ورزشی
 public   class ProgramSport : BaseEntity
    {

        public ProgramSport()
        {

        }
    
        public Nullable<int> ProgramSportId { get; set; }
        public string NameProgram { get; set; }
        //
        // public int FoeldSport { get; set; }
        // public int HallSport { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string DetailsSport { get; set; }
      //  public  Days  DaysOfYear{ get;set; }
        public Days DaysOfYear { get; set; }
        public string Day { get; set; }

        public int AbsenceCost { get; set; }
            [ForeignKey("PMemberSportRef")]
        public virtual ClubSport.Domain.MemberSport.MemberSport M_Sport { get; set; }
        public int PMemberSportRef { get; set; }
        [ForeignKey("FieldSportRef")]
        public virtual ClubSport.Domain.FieldSport.FieldSport F_Sport { get; set; }
        public int FieldSportRef { get; set; }
        [ForeignKey("HallSportRef")]
        public virtual ClubSport.Domain.HallSport.HallSport H_Sport { get; set; }
        public int HallSportRef { get; set; }
    
        [ForeignKey("HallSportRef")]
        public virtual ClubSport.Domain.EventSport.EventSport E_Sport { get; set; }
        public int EventSportRef { get; set; }

    }
}
