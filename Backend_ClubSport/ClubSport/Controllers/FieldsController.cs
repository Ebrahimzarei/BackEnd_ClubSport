using ClubSport.Domain.EventSport;
using ClubSport.Domain.FieldSport;
using Contracts.FieldSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubSport.Controllers
{
    //[Route("api/[controller]")]
    //  [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Fields")]
    public class FieldsController : Infrastrucher.BaseApiController
    {
        private readonly IFieldSportRepository FieldRepository;
        public FieldsController(IFieldSportRepository FieldRepository) : base()
        {
            this.FieldRepository = FieldRepository;
        }
        [HttpPost("AddField")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<FieldSport>>> AddFields(FieldSport item)
        {


            FieldRepository.Add(item);
            var list = FieldRepository.GetAll().ToList();
            return list;
        }

        [HttpPost("DeleteFieldItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<FieldSport>>> DeleteEventItem(int id)
        {

            FieldRepository.Delete(id);
            var list = FieldRepository.GetAll().ToList();
            return list;

        }
        [HttpPost("updateFieldItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
         System.Threading.Tasks.Task
          <Microsoft.AspNetCore.Mvc.ActionResult<List<FieldSport>>>
    UpdateField(int id, FieldSport item)
        {







            FieldRepository.Update(id,item);
           // FieldRepository.Delete(id);
            var list = FieldRepository.GetAll().ToList();
            return list;





        }
        [Authorize(Roles = "Admin")]
        [HttpPost("GetFieldsItems")]
        public async Task<ActionResult<IList<FieldSport>>> GetEventsItems(int id)
        {



             
            var list = FieldRepository.GetAll().ToList();
            return list;
        }
        [HttpPost("FindField/{id}")]
        [Authorize(Roles = "Admin")]
        public async
                System.Threading.Tasks.Task
                 <Microsoft.AspNetCore.Mvc.ActionResult<FieldSport>>
           FindEvent(int id)
        {
          var Find=  FieldRepository.Get(id);
          
            return Find;
           
            //  return result;

        }
    }
}
