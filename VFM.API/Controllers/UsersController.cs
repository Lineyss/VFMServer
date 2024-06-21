using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VFM.API.Models;
using VFM.Core.Interfaces;
using VFM.Core.Models;

namespace VFM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await userService.GetAllUser();

            var respone = users.Select(element => new UsersResponse(element.ID, element.Email, element.Password));

            return Ok(respone);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {
            var (user, error) = Core.Models.User.Create(Guid.NewGuid(), request.Email, request.Password);

            if(string.IsNullOrEmpty(error))
            {
                return Ok(await userService.CreateUser(user));
            }

            return BadRequest(error);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UsersRequest request)
        {
            return Ok(await userService.UpdateUser(id, request.Email, request.Password));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            return Ok(await userService.DeleteUser(id));
        }

    }
}
