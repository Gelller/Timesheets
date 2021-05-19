using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Interfaces
{
    public interface IPersonRepo
    {
        Person GetById(int id);
        Person GetByName(string name);
        List<Person> GetСollection(int skip, int take);
        int AddToCollection(Person person);
        int UpdateCollection(Person person);
        int DeleteFromCollection(int id);
    }
}
