using System.Data.Entity;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearner.DataAccess
{
    public class LessonsLearnedDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}