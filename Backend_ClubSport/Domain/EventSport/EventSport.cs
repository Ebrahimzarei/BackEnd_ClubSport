
using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ClubSport.Domain.HallSport;

namespace ClubSport.Domain.EventSport
{
    //رویداد ورزشی
   public class EventSport: BaseEntity
    {
        public EventSport()
        {

        }
       
        public Nullable<int> EventId { get; set; }
        public string NameEvent { get; set; }
        public string EventResult { get; set; }
        //نام داور
        public string RefeRee { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        //رشته ورزشی
        // public int F_Sport { get; set; }
        //سالن ورزشی
        [ForeignKey("HallSportRef")]
        public ClubSport.Domain.HallSport.HallSport H_Sport { get; set; }
        public int HallSportRef { get; set; }
        //سطح دسترسی
      //  public Nullable <int>R_AccessRef { get; set; }
      //  [ForeignKey("R_AccessRef")]
      //  public ClubSport.Domain.RoleAccess.RoleAccess R_Access { get; set; }
        [ForeignKey("FieldSportRef")]
        public ClubSport.Domain.FieldSport.FieldSport F_Sport { get; set; }
        public int FieldSportRef { get; set; }
        [ForeignKey("ProgramSportRef")]
        public ClubSport.Domain.ProgramSport.ProgramSport P_Sport { get; set; }
        public Nullable<int> ProgramSportRef { get; set; }
        
    }
}
