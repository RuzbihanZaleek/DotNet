using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    // [Route("api/[controller]")] //this will take the controller name (VillaAPI) automatically 
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDto> GetVillas() 
        {
            return new List<VillaDto>
            {
                new VillaDto{ Id=1, Name="Pool Villa"},
                new VillaDto{ Id=2, Name="Beach Villa"}
            };
        }
    }
}
