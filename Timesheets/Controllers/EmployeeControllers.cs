using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models;
using AutoMapper;


namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IMapper _mapper;

        public EmployeeControllers(IEmployeeManager employeeManager, IMapper mapper)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _employeeManager.GetItem(id);
            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddToCollection([FromBody] EmployeeDto employee)
        {
            var id = await _employeeManager.Create(_mapper.Map<Employee>(employee));
            return Ok(id);
        }
        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeDto employee)
        {
            await _employeeManager.Update(id, _mapper.Map<Employee>(employee));
            return Ok();
        }
    }
}
