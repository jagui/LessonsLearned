using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace LessonsLearner.DataAccess
{
    public class LessonsLearnedDbContextInitializer : DropCreateDatabaseIfModelChanges<LessonsLearnedDbContext>
    {

    }
}
