using ClubSport.Domain.HallSport;
using ClubSport.Infrastrucher;
using Contracts.HallSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Halls")]

    public class HallsController : BaseApiController
    {
        private readonly IHallSportRepository HallRepository;

        public HallsController(IHallSportRepository HallRepository) : base()
        {
            this.HallRepository = HallRepository;
        }
        [HttpPost("AddHall")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<HallSport>>> AddHalls(HallSport item)
        {
            item.Id = null;
            try
            {
                HallRepository.Add(item);
            }
            catch(Exception ex)
            {
                string m = ex.Message;
               

            }
         
            var list = HallRepository.GetAll().ToList();

            return list;
        }
        [HttpPost("DeleteHallItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<HallSport>>> DeleteHallItem(int id)
        {

            if (id != null)

                HallRepository.Delete(id);

            var list = HallRepository.GetAll().ToList();
            return list;


        }
        [HttpPost("UpdateHallItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
      System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.ActionResult<List<HallSport>>>
 UpdateField(int id, HallSport item)
        {


            if (id != null)
                try
                {
          HallRepository.Update(id, item);
                }
                catch (Exception ex)
                {
                    item.MemberSportRef = 111;
                    HallRepository.Update(id, item);
                    HallRepository.Delete(id);


                }



            var list = HallRepository.GetAll().ToList();
            return list;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("GetHallItems")]
        public async Task<ActionResult<IList<HallSport>>> GetHallItems()
        {






            var list = HallRepository.GetAll().ToList();
            return list;
        }
        [HttpPost("FindHall/{id}")]
        [Authorize(Roles = "Admin")]
        public async
          System.Threading.Tasks.Task
           <Microsoft.AspNetCore.Mvc.ActionResult<HallSport>> FindHall(int id)

        {

           
                var Find = HallRepository.Get(id);
           



           
            return Find;

        }
    }
}
