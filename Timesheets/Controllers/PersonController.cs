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
        private readonly IMapper _mapper;

        public PersonController(IPersonManager personManager, IMapper mapper)
        {
            _personManager = personManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
           var person= _personManager.GetById(id);
           return Ok(person);
        }

        [HttpPost]
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
                
                
            
    }


    
}
