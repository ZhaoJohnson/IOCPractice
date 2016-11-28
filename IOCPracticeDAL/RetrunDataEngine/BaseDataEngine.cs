using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class BaseDataEngine : IRetrunDataEngine
    {
        protected Dictionary<string, IDAO> KeyDaos = new Dictionary<string, IDAO> ();
        protected IDAO BaseDao;

        protected BaseDataEngine ()
        {
            KeyDaos.Add (typeof (UserModel).Name, new UserDAO<User> ());
            KeyDaos.Add (typeof (CompanyModel).Name, new CompanyDAO<Company> ());
            KeyDaos.Add (typeof (MenuModel).Name, new MenuDAO<Menu> ());
            KeyDaos.Add (typeof (UserMenuMappingModel).Name, new UserMenuMappingDAO<UserMenuMapping> ());
        }

        public virtual T Add<T> ( T model ) where T : class, new()
        {
            throw new NotImplementedException ();
        }

        public virtual T QuerySingle<T> ( object objectKey ) where T : class, new()
        {
            throw new NotImplementedException ();
        }

        public virtual T AddorUpdate<T> ( T model ) where T : class, new()
        {
            throw new NotImplementedException ();
        }

        public virtual IList<T> SkipTable<T> ( int pageSize, int pageIndex ) where T : class, new()
        {
            return null;
        }

        public int GetCount ()
        {
            return 0;
        }

        public virtual IEnumerable<T> SkipData<T> ( int pageSize, int pageIndex ) where T : class, new()
        {
            return null;
        }

        public virtual IEnumerable<T> OffSetData<T> ( int pageSize, int pageIndex ) where T : class, new()
        {
            return null;
        }
    }
}