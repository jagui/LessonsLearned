using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearner.DataAccess
{
    public class PersonAggregate : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
