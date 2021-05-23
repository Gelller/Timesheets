using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUsersManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userManager.GetItem(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }
        [Authorize(Roles = "user")]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddToCollection([FromBody] UserDto user)
        {

         //   var id = await _userManager.Create(_mapper.Map<User>(user));
                
            var id = await _userManager.Create(user);
            return Ok(id);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto user)
        {        
            await _userManager.Update(id, _mapper.Map<User>(user));
            return Ok();
        }
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.Delete(id);
            return Ok();
        }
    }
}
