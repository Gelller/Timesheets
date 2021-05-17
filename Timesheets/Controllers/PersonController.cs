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
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet("persons/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
           var person= _personManager.GetById(id);
           return Ok(person);
        }
        [HttpGet("persons/search/{term}")]
        public IActionResult GetByName([FromRoute] string term)
        {
            var person = _personManager.GetByName(term);
            return Ok(person);
        }

        [HttpGet("persons/{skip}/to/{take}")]
        public IActionResult GetСollection([FromRoute] int skip, [FromRoute] int take)
        {
            var person = _personManager.GetСollection(skip,take);
            return Ok(person);
        }

        [HttpPost("persons")]
        public IActionResult AddToCollection([FromBody] PersonDto person)
        {        
            var id =_personManager.AddToCollection(new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Company = person.Company,
                Age = person.Age

            });
            return Ok(id);
        }

        [HttpPut("persons")]
        public IActionResult UpdateCollection([FromBody] Person person)
        {
            var id = _personManager.UpdateCollection(person);    
            return Ok(id);
        }

        [HttpDelete("persons/{id}")]
        public IActionResult DeleteFromCollection([FromRoute] int id)
        {
            return Ok( _personManager.DeleteFromCollection(id));
        }
    }   
}
