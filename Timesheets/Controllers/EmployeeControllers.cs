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
    public class EmployeeControllers : TimesheetBaseController
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IMapper _mapper;

        public EmployeeControllers(IEmployeeManager employeeManager, IMapper mapper)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
        }
        /// <summary> Возвращяет запись о сотруднике по id </summary>
        [Authorize(Roles = "user, admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _employeeManager.GetItem(id);
            return Ok(employee);
        }
        /// <summary> Возвращяет запись о всех сотруднике</summary>
        [Authorize(Roles = "user, admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }
        /// <summary> Создает запись о сотруднике </summary>
        [Authorize(Roles = "user, admin")]
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddToCollection([FromBody] EmployeeDto employee)
        {
            var id = await _employeeManager.Create(_mapper.Map<Employee>(employee));
            return Ok(id);
        }
        /// <summary> Обнавляет запись о сотруднике </summary>
        [Authorize(Roles = "user, admin")]
        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeDto employee)
        {
            await _employeeManager.Update(id, _mapper.Map<Employee>(employee));
            return Ok();
        }
        /// <summary> Удаляет запись о сотруднике </summary>
        [Authorize(Roles = "user, admin")]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _employeeManager.Delete(id);
            return Ok();
        }
    }
}
