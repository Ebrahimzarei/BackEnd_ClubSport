using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Infrastrucher
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    // [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
   
    [Microsoft.AspNetCore.Mvc.Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class BaseApiController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public BaseApiController():base()
        {

        }
    }
}
