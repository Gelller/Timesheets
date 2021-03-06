using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
  //  [Authorize]
    public class UsersController :TimesheetBaseController
    {
        private readonly IUsersManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUsersManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        /// <summary> Возвращяет записиь о пользователе по id </summary>
       // [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userManager.GetItem(id);
            return Ok(user);
        }
        /// <summary> Возвращяет все записи о пользователях </summary>
     //   [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }
        /// <summary> Создает запись о пользователе  </summary>
       // [Authorize(Roles = "admin")]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddToCollection([FromBody] UserDto user)
        {
           var id = await _userManager.Create(_mapper.Map<User>(user));
           return Ok(id);
        }
        /// <summary> Обновляет запись о пользователе  </summary>
       // [Authorize(Roles = "admin")]
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto user)
        {        
            await _userManager.Update(id, _mapper.Map<User>(user));
            return Ok();
        }
        /// <summary> Удаляет запись о пользователе </summary>
        //[Authorize(Roles = "admin")]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.Delete(id);
            return Ok();
        }      
    }
}
