using ClubSport.Domain.ProgramSport;
using ClubSport.Infrastrucher;
using Contracts.MemberSport;
using Contracts.ProgramSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/ProgramSport")]
    public class ProgramsController : BaseApiController
    {
        private readonly IProgramSportRepository ProgramRepository;
        private readonly IMemberSportRepository MemberSportRepository;
        public ProgramsController(IProgramSportRepository ProgramRepository, IMemberSportRepository MemberSportRepository) : base()
        {
            this.ProgramRepository = ProgramRepository;
            this.MemberSportRepository = MemberSportRepository;

        }
        [HttpPost("AddProgram")]
       [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ProgramSport>>> AddProgram([FromBody] ProgramSport item)
        {
            if (item!=null)
            {
              //  item.DaysOfYear.Id = null;
                ProgramRepository.Add(item);
                var GetAll = ProgramRepository.GetAll().ToList();
                return Ok(value: GetAll);
            }

     
            return BadRequest();
        }
        [HttpPost("DeleteProgramItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ProgramSport>>> DeleteProgramItem(int id)
        {

            bool v = id != null;
            if (v)
            {


                ProgramRepository.Delete(id);
                var list = ProgramRepository.GetAll().ToList();

                return Ok(value: list);
            }
            return BadRequest();
        }
        [HttpPost("UpdateProgram/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<List< ProgramSport>>>
UpdateProgram(int id, ProgramSport item)
        {
            if (id == null)
            {
                return BadRequest();
            }
          //  item.ProgramSportId = id;
            //item.DaysOfYear.Id = null;
            item.Id = null;
         
         
            ProgramSport Psport = new ProgramSport
            {
                AbsenceCost = item.AbsenceCost,
                Day=item.Day,
                DaysOfYear=item.DaysOfYear,
                DetailsSport=item.DetailsSport,
                FieldSportRef=item.FieldSportRef,
           PMemberSportRef=item.PMemberSportRef,
           HallSportRef=item.HallSportRef,
                FromDate=item.FromDate,
                E_Sport=null,
                F_Sport=null,
                Id=null,
                NameProgram=item.NameProgram,
                H_Sport=null,
                M_Sport=null,
           ToDate=item.ToDate,
           ProgramSportId=item.ProgramSportId
            };

            try
            {
                ProgramRepository.Update(id, Psport);
              //  ProgramRepository.Delete(id);
            }
            catch (Exception ex)
            {
                string x = ex.InnerException.Message;
                throw;
            }

       


          var GetAll=  ProgramRepository.GetAll().ToList();
            return GetAll;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("GetProgramItems")]
        public async Task<ActionResult<IList<ProgramSport>>> GetMembersItems()
        {

            var all = ProgramRepository.GetAll().ToList();
          
            return Ok(value: all);
        }
        [HttpPost("FindsPrograms/{id}")]
        [Authorize(Roles = "Admin")]
        public async
 System.Threading.Tasks.Task
  <Microsoft.AspNetCore.Mvc.ActionResult< ProgramSport >>
FindMember(int id)
        {
            if (id!=null)
            {
            var findItem = ProgramRepository.Get(id);
            return Ok(value: findItem);
            }
            return BadRequest();
        
            //  return result;

        }
    }
}
