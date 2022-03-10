using ClubSport.Domain;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClubSport.Domain.ServicesSport
{
    //خدمات ورزشی
   public class ServicesSport : BaseEntity
    {
        public ServicesSport()
        {

        }
        
        public Nullable< int> ServiceId { get; set; }
        public string NameService { get; set; }
        [ForeignKey("HallSportRef")]
        public ClubSport.Domain.HallSport.HallSport H_sport { get; set; }
        public int HallSportRef { get; set; }
        public string CoachSport { get; set; }

    }
}
