
using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubSport.Domain.Member
{
  public  class Member: BaseEntity
    {
        public Member()
        {

        }
        //اعضا
        public int Memberid { get; set; }
        public string FullName { get; set; }
        public string Natinalcode { get; set; }

        public string Photo { get; set; }

        public string FatherName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        //
        public string Role { get; set; }

       // public virtual ClubSport.Domain.RoleAccess.RoleAccess R_Access { get; set; }

    }
}
