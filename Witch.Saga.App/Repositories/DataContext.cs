using Microsoft.EntityFrameworkCore;
using System;
using Witch.Saga.App.Models;

namespace Witch.Saga.App.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Person> Person { get; set; }

        internal void Update(Person user, Guid? userId)
        {
            throw new NotImplementedException();
        }
    }
}
