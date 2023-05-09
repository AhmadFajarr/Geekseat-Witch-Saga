using System;

namespace Witch.Saga.App.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public int? AgeOfDeath { get; set; }
        public int? YearOfDeath { get; set; }
        public int? AverageNumber { get; set; }
    }
}
