using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebApp.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {
       private readonly IUserService userService;

       public UserController(IUserService userService)
       {
           this.userService = userService;
       }

       [HttpGet]

       public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
       {
           Console.WriteLine("Here");
           try
           {
               var user =  userService.ValisateUser(username, password);
               return Ok(user);
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
       }

       [HttpPost]

       public async Task<ActionResult> RegisterUser([FromBody] User user)
       {
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
           try {
                 userService.RegisterUser(user);
                 return Ok();
           } catch (Exception e) {
               Console.WriteLine(e);
               return StatusCode(500, e.Message);
           }
       }
       
       
    }
}