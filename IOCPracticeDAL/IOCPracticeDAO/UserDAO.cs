using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;
using IOCPracticeModel;

namespace IOCPracticeDAL.IOCPracticeDAO
{
    public class UserDAO : BasicDAO<User>
    {
        public DbSet<User> UserDb => base.dbContext.User;
    }
}