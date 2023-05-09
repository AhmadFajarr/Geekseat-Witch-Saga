using System;
using System.Collections.Generic;
using System.Linq;
using Witch.Saga.App.Models;
using Witch.Saga.App.Models.ViewModel;
using Witch.Saga.App.Repositories;

namespace Witch.Saga.App.Services
{
    public class PersonServices
    {
        private readonly DataContext _db;

        public PersonServices(DataContext db)
        {
            _db = db;
        }


        // get all list from db
        public List<Person> GetList()
        {
           return _db.Person.OrderByDescending(x => x.Id).ToList();
        }

        public Guid Create(Person personData)
        {
            personData.Id = Guid.NewGuid();
            _db.Person.Add(personData);
            _db.SaveChanges();

            return personData.Id;
        }
    }
}
