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
         int AddToCollection(Person person);
    }
}
