using ClubSport.Domain.ServicesSport;
using ClubSport.Infrastrucher;
 
using Contracts.ServicesSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Services")]

    public class ServicesController : BaseApiController
    {
        private readonly IServicesSportRepositroy ServicesSportRepository;
        public ServicesController(IServicesSportRepositroy ServicesSportRepository) : base()
        {
            this.ServicesSportRepository = ServicesSportRepository;
        }
       
        [Authorize(Roles = "Admin")]
        [HttpPost("AddServices")]
        public async Task<ActionResult<List<ServicesSport>>> AddService(ServicesSport item)
        {

            item.Id = null;
            item.ServiceId = null;

            ServicesSportRepository.Add(item);
            var list = ServicesSportRepository.GetAll().ToList() ;
            return list;
        }
        [HttpPost("DeleteServicesItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ServicesSport>>> DeleteProgramItem(int id)
        {

            bool v = id != null;
            if (v)
            {


                ServicesSportRepository.Delete(id);
                var list = ServicesSportRepository.GetAll().ToList();

                return Ok(list);
            }
            return BadRequest();
        }
        [HttpPost("UpdateServicesItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<List<ServicesSport>>>
UpdateServices(int id, ServicesSport item)
        {
            if (id != item.Id && id == null)
            {
                return BadRequest();
            }



            ServicesSportRepository.Update(id, item);
            ServicesSportRepository.Delete(id);

            var list = ServicesSportRepository.GetAll().ToList();

            return Ok(list);


          
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("GetServicesItems")]
        public async Task<ActionResult<IList<ServicesSport>>> GetServicesItems()
        {

            var list = ServicesSportRepository.GetAll().ToList() ;
           
            return Ok(value: list);
        }
        [HttpPost("FindsServices/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<ServicesSport>>
FindServices(int id)
        {
            //if (id != item.Id)
            //{
            //    return BadRequest();
            //}
            if (id != null)
            {
              var find=  ServicesSportRepository.Get(id);
                return find;
            }
            return BadRequest();
            //  return result;

        }
    }
}
