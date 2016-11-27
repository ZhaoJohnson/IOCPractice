using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class UserDataEngine
    {
        protected UserDAO UserDAO => new UserDAO ();

        public UserModel Add ( UserModel model )
        {
            var AddUser = new User ().SyncFromOtherObj (model);
            var result = UserDAO.Add (AddUser);
            if (result == null) return null;
            return new UserModel ().SyncFromOtherObj (result);
        }

        public UserModel QuerySingle ( object objectKey )
        {
            var result = UserDAO.QuerySingle (objectKey);
            if (result == null) return null;
            return new UserModel ().SyncFromOtherObj (result);
        }

        public UserModel AddorUpdate ( UserModel model )
        {
            return null;
        }

        public IList<UserModel> SkipTable ( int pageSize, int pageIndex )
        {
            return null;
        }

        public int GetCount ()
        {
            return 0;
        }

        public IEnumerable<UserModel> SkipData ( int pageSize, int pageIndex )
        {
            return null;
        }

        public IEnumerable<UserModel> OffSetData ( int pageSize, int pageIndex )
        {
            return null;
        }
    }
}