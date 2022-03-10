using ClubSport.Domain.RoleAccess;
using ClubSport.Infrastrucher;
using Contracts.RoleAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{

    public class RolesController : BaseApiController
    {
        private readonly IRoleAccessRepositroy RoleRepository;
        public RolesController(IRoleAccessRepositroy RoleRepository) : base()
        {
            this.RoleRepository = RoleRepository;
        }
        [HttpPost("api/AddRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<RoleAccess>>> AddRole(RoleAccess item)
        {
            if (item != null)
            {
                RoleRepository.Add(item);
                var List = RoleRepository.GetAll().ToList();
                return Ok(value: List);
            }
            return BadRequest();


        }
        [HttpPost("/api/DeleteRoleItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<RoleAccess>>> DeleteRoleItem(int id)
        {

            bool v = id != null;
            if (v)
            {

                RoleRepository.Delete(id);
                var list = RoleRepository.GetAll().ToList();
                return Ok(value: list);
            }
            return BadRequest();
        }
        [HttpPost("/api/UpdateRoleItem/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<List<RoleAccess>>>
UpdateRole(int id, RoleAccess item)
        {
            if (id != item.Id && item == null)
            {
                return BadRequest();
            }
            RoleRepository.Update(id, item);
            var list = RoleRepository.GetAll().ToList();
            return Ok(value: list);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/api/GetRolesItems")]
        public async Task<ActionResult<IList<RoleAccess>>> GetRolesItems()
        {

            var list = RoleRepository.GetAll().ToList();
            return Ok(value: list);
        }
        [HttpPost("/api/FindsRoles/{id}")]
        [Authorize(Roles = "Admin")]
        public async
System.Threading.Tasks.Task
<Microsoft.AspNetCore.Mvc.ActionResult<RoleAccess>>
FindRoles(int id)
        {
            //if (id != item.Id)
            //{
            //    return BadRequest();
            //}
            if (id != null)
            {
                var FindItem = RoleRepository.Get(id);
                return Ok(value: FindItem);
            }

            return BadRequest();
            //  return result;

        }
    }
}
