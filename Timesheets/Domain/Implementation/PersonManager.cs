using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Data.Interfaces;

namespace Timesheets.Domain.Implementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepo _personRepo;

        public PersonManager(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public Person GetById(int id)
        {
           return _personRepo.GetById(id);
        }

        public int AddToCollection(Person person)
        {
             return _personRepo.AddToCollection(person);
        }
    }
}
