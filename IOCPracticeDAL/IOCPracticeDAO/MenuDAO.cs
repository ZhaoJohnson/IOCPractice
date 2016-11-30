using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;

namespace IOCPracticeDAL.IOCPracticeDAO
    {
    public class MenuDAO<T> : BasicDAO, IDAO
        where T:Menu
    {
        public DbSet<Menu> MenuDb => base.dbContext.Menu;
    }
    }