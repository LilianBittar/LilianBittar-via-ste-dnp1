using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebApp.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AdultsController : ControllerBase
    {
        private IAdultData adultData;

        public AdultsController(IAdultData adultData)
        {
            this.adultData = adultData;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync([FromQuery] int? adultId, [FromQuery] string name, [FromQuery] int? age, [FromQuery] string sex) {
            try {
                IList<Adult> adults = await adultData.GetAdultsAsync(adultId, name, age, sex);
                Console.WriteLine(adults.Count);
                return Ok(adults);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> RemoveAdultAsync([FromRoute] int id) {
            try {
                await adultData.RemoveAdultAsync(id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody] Adult adult) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                Adult added = await adultData.AddAdultAsync(adult);
                return Created($"/{added.Id}",added); // return newly added adult, to get the auto generated id
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdultAsync([FromBody] Adult adult) {
            try
            {
                Adult updatedAdult = await adultData.UpdateAdultAsync(adult);
                if (adult == null) throw new Exception();
                return Ok(updatedAdult); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


     
    }
}