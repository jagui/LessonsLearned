using System.Data.Entity;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearner.DataAccess
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}