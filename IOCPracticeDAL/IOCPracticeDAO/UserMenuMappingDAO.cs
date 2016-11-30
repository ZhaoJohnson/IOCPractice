using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;

namespace IOCPracticeDAL.IOCPracticeDAO
    {
    public class UserMenuMappingDAO<T> : BasicDAO, IDAO
        where T:UserMenuMapping
    {
        public DbSet<UserMenuMapping> MappingDb => base.dbContext.UserMenuMapping;

        public IEnumerable<UserMenuMapping> GetUserMenuMappingsByUserId(int userid)
        {
            return MappingDb.Where(p => p.UserId == userid);
        }

        public IEnumerable<UserMenuMapping> GetUserMenuMappingsByMenuId(int menuid)
        {
            return MappingDb.Where(p => p.MenuId == menuid);
        }
    }
    }