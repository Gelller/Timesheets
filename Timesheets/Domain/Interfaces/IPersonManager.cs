using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
namespace Timesheets.Domain.Interfaces
{
    public interface IPersonManager
    {
         Person GetById(int id);
         Person GetByName(string name);
         List<Person> GetСollection(int skip, int take);
         int UpdateCollection(Person person);
         int AddToCollection(Person person);
         int DeleteFromCollection(int id);
    }
}
