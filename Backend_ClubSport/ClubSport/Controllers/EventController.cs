using ClubSport.Domain.EventSport;
using ClubSport.Infrastrucher;
using Contracts.EventSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
  
    //[Microsoft.AspNetCore.Mvc.Route("[controller]")]
   // [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Event")]
    public class EventController : BaseApiController
    {
        private   readonly IEventSportRepository eventRepository;
        public EventController(IEventSportRepository eventRepository) : base()
        {
            this.eventRepository = eventRepository;
        }
        [HttpPost("AddEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Domain.EventSport.EventSport>>> AddEvent(Domain.EventSport.EventSport modelEvent)
        {
            modelEvent.EventId = null;
            modelEvent.Id = null;
           // modelEvent.R_AccessRef = null;
            try
            {
                eventRepository.Add(modelEvent);
            }
            catch (Exception ex)
            {
                string x = ex.Message;
               
            }
         
            var ListEvent = eventRepository.GetAll().ToList();
            return ListEvent;
        }
        [HttpPost("FindEvent/{id}")]
        [Authorize(Roles = "Admin")]

         
            
         public Microsoft.AspNetCore.Mvc.ActionResult<Domain.EventSport.EventSport>
            FindEvent(int id)
        {


            var FindEvent =  eventRepository.Get(id);
           
            return FindEvent;

        }
        [HttpPost("DeleteEventItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<EventSport>>> DeleteEventItem(int id)
        {

            if (id != null)
            {
                eventRepository.Delete(id);
            }
            var list = eventRepository.GetAll().ToList() ;
            return list;
        }

        [HttpPost("updateEventsItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
                 System.Threading.Tasks.Task
                  <Microsoft.AspNetCore.Mvc.ActionResult<List< EventSport>>>
            UpdateEvent(int id, EventSport item)
        {



            if (id != null &&item!=null)
            {
                try
                {
  eventRepository.Update(id, item);
                }
                catch (Exception ex)
                {
                    string cc = ex.Message;

                    throw;
                }
              
              //  eventRepository.Delete(id);
            }
            var list = eventRepository.GetAll().ToList() ;
 
                return list;




            
          
        }
      [Authorize(Roles = "Admin")]
      
        [HttpPost("GetEventsItems")]
        public async Task<ActionResult<List<EventSport>>> GetEventsItems()
        {
            var list = eventRepository.GetAll().ToList();
          
            return list;
        }

    }
}
