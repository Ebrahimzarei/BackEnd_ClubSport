using ClubSport.Domain.MemberSport;
using ClubSport.Infrastrucher;
using Contracts.MemberSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
  //  [Microsoft.AspNetCore.Mvc.Route("api/MemberSport")]
    public class MembersSportController : BaseApiController
    {
        private readonly IMemberSportRepository MemberSportRepository;
        public MembersSportController(IMemberSportRepository MemberSportRepository) : base()
        {
            this.MemberSportRepository = MemberSportRepository;
        }
        [HttpPost("api/FindMembersSport/{id}")]
        [Authorize(Roles = "Admin")]
        public async
    System.Threading.Tasks.Task
     <Microsoft.AspNetCore.Mvc.ActionResult< MemberSport >> FindMember(int id)

        {
            var FindItem = MemberSportRepository.Get(id);
               // return Ok(FindItem);
       


          
        return FindItem;

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("api/GetMembersSportItems")]
        public async Task<ActionResult<List<MemberSport>>> GetMembersSportItems()
       {
            
            var all =   MemberSportRepository.GetAll().ToList();
            //  List<MemberSport> x=new List<MemberSport>();
            //foreach (var item in all)
            //{

            //}

            return Ok(value: all);
        }
        [HttpPost("api/AddMemberSport")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<MemberSport>>> AddMembersSport(MemberSport item)
        {
            item.Id = null;

            MemberSportRepository.Add(item);
            var all = MemberSportRepository.GetAll().ToList();
            return Ok(value: all);
        }
        [HttpPost("api/DeleteMemberSportItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<MemberSport>>> DeleteMemberSportIItem(int id)
        {

            try
            {
                MemberSportRepository.Delete(id);
            }
            catch (Exception ex)
            {

                return BadRequest(  ex.Message);
            }
         

            var all = MemberSportRepository.GetAll().ToList();
            return Ok(value: all);
        }
        [HttpPost("api/UpdateMemberSportItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<List< MemberSport>>>
UpdateMemberSport(int id, MemberSport item)
        {
            if (id ==null)
            {
                return BadRequest();
            }

            MemberSportRepository.Update(id,item);
            MemberSportRepository.Delete(id);


            var GetAll = MemberSportRepository.GetAll().ToList();

            
                return Ok(value: GetAll);




          
        }



    }
}
