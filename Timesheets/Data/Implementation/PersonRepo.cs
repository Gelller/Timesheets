using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Implementation
{
    public class PersonRepo : IPersonRepo
    {

        private static List<Person> data =
            new List<Person>() {
            new Person {Id = 1, FirstName = "Veda", LastName = "Richmond", Email = "ligula@necluctus.edu", Company = "Quisque Ac Libero LLP", Age = 42 },
            new Person { Id = 2, FirstName = "Demetria", LastName = "Andrews", Email = "feugiat.metus@penatibuset.org", Company = "Nulla Facilisi Foundation", Age = 31 },
            new Person { Id = 3, FirstName = "Byron", LastName = "Holmes", Email = "neque.Sed.eget@non.co.uk", Company = "Et Associates", Age = 63 },
            new Person { Id = 4, FirstName = "Alexander", LastName = "Cummings", Email = "egestas.ligula@ultricesDuisvolutpat.ca", Company = "Vel Institute", Age = 23 },
            new Person { Id = 5, FirstName = "Melinda", LastName = "Miles", Email = "justo.nec.ante@nonummyFusce.ca", Company = "Eu Nibh Vulputate Company", Age = 64 }
            };

        public int AddToCollection(Person person)
        {
            // data.Add(new Person { Id = 10, FirstName = person.FirstName, LastName = person.LastName, Email = person.Email, Company = person.Company, Age = person.Age });
            data.Add(person);
            return 10;
        }

        public void DeleteFromCollection(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            return data.Where(x => x.Id == id).FirstOrDefault();
        }

        public Person GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetСollection(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void UpdateCollection(PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}
