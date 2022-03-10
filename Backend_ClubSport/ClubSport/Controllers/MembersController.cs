using ClubSport.Domain.HallSport;
using ClubSport.Domain.Member;
using ClubSport.Infrastrucher;
using Contracts.Member;
using Contracts.UserServices;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Members")]

    public class MembersController : BaseApiController
    {
        private readonly IMemberRepository MemberRepository;
        private readonly IUserService _userService;
        public MembersController(IMemberRepository MemberRepository, IUserService userService) : base()
        {
            this.MemberRepository = MemberRepository;

            _userService = userService;

        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<User> Login(UserLogin user)
        {
            // var User = await _MemberService.Authenticate(MemberItem.UserName, MemberItem.Password);
           var User = _userService.Authenticate(username: user.username, password: user.password);
   
          if (user!=null)
            {
            
                return User;
            }


            return null;


        }
        [HttpPost("AddMember")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Member>>> AddMember(Member item)
        {
            MemberRepository.Add(item);
            var list = MemberRepository.GetAll().ToList();

            return list;
           
        }
        [HttpPost("DeleteMemberItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Member>>> DeleteHallIItem(int id)
        {

            MemberRepository.Delete(id);
            var list = MemberRepository.GetAll().ToList();
            return Ok(list);
           
        
        }
        [HttpPost("UpdateMemberItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<List< Member>>> UpdateField(int id, Member item)

        {

            MemberRepository.Update(id,item);
          //  MemberRepository.Delete(id);

            var list = MemberRepository.GetAll().ToList();
            return Ok(list);
        }
        [HttpPost("FindsMembers/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Member>> FindMember(int id)

        {

         var FindItem=   MemberRepository.Get(id);
          
            return Ok(FindItem);


        }
        [HttpPost("GetAllMember")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Member>> GetAllMember(int id)

        {
            var AllMember = MemberRepository.GetAll().ToList();
            return Ok(AllMember);
        }

        }
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }

 

}
