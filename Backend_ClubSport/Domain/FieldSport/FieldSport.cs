using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubSport.Domain.FieldSport
{
    //رشته ورزشی
 public   class FieldSport: BaseEntity
    {
        public FieldSport()
        {

        }
        public int FieldId { get; set; }
        public string NameField { get; set; }
        public int CodeSportField { get; set; }
        //
        public ClubSport.Domain.ProgramSport.ProgramSport P_Sport { get; set; }

        public ClubSport.Domain.EventSport.EventSport E_Sport { get; set; }
    }
}
