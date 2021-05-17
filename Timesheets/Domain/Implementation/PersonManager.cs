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
        public Person GetByName(string name)
        {
            return _personRepo.GetByName(name);
        }
        public List<Person> GetСollection(int skip, int take)
        {
            return _personRepo.GetСollection(skip, take);
        }
        public int AddToCollection(Person person)
        {
             return _personRepo.AddToCollection(person);
        }          
        public int UpdateCollection(Person person)
        {
           return _personRepo.UpdateCollection(person);
        }
        public int DeleteFromCollection(int id)
        {
            return _personRepo.DeleteFromCollection(id);
        }
    }
}
