using System;
using System.ComponentModel.DataAnnotations;

namespace ClubSport.Domain
{
    public class BaseEntity
    {
        [Key]
        public Nullable<int> Id { get; set; }
        
    }
}
