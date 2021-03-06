﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public abstract class BasicDataEngine<TSource, TDbClass> : IDataEngine<TSource>
        where TSource : class, new()
        where TDbClass : class, new()
    {
        protected Dictionary<string, IDAO> KeyDaos = new Dictionary<string, IDAO> ();
        protected IDAO BaseDao => KeyDaos[typeof (TSource).Name];

        protected BasicDataEngine ()
        {
            KeyDaos.Add (typeof (UserModel).Name, new UserDAO<User> ());
            KeyDaos.Add (typeof (CompanyModel).Name, new CompanyDAO<Company> ());
            KeyDaos.Add (typeof (MenuModel).Name, new MenuDAO<Menu> ());
            KeyDaos.Add (typeof (UserMenuMappingModel).Name, new UserMenuMappingDAO<UserMenuMapping> ());
        }

        public IList<TSource> GetData()
        {
            return BaseDao.GetData<TDbClass>().Select(single => new TSource().SyncFromOtherObj(single)).ToList();
        }

        public virtual TSource AddEntity ( TSource tSource )
        {
            var AddEntity = new TDbClass ().SyncFromOtherObj (tSource);
            var result = BaseDao.Add (AddEntity);
            return result == null ? null : new TSource ().SyncFromOtherObj (result);
        }

        public virtual TSource QuerySingle ( object objectKey )
        {
            var result = BaseDao.QuerySingle<TDbClass> (objectKey);
            if (result == null) return null;
            return new TSource ().SyncFromOtherObj (result);
        }

        public TSource GetRandomData()
        {
            return new TSource().SyncFromOtherObj(BaseDao.GetRandomData<TDbClass>(typeof (TDbClass)));
        }

        public virtual TSource AddorUpdate ( TSource model )
        {
            var AddEntity = new TDbClass ().SyncFromOtherObj (model);
            var result = BaseDao.AddorUpdate (AddEntity);
            return result == null ? null : new TSource ().SyncFromOtherObj (result);
        }

        public virtual IList<TSource> SkipTable ( int pageSize, int pageIndex )
        {
            var result = BaseDao.SkipTable<TDbClass> (pageSize, pageIndex);
            return !result.Any () ? null : result.Select(item => new TSource().SyncFromOtherObj(item)).ToList();
        }

        public virtual IEnumerable<TSource> OffSetData ( int pageSize, int pageIndex )
        {
            var result = BaseDao.OffSetData<TDbClass> (typeof (TDbClass), pageSize, pageIndex);
            return !result.Any () ? null : result.Select(item => new TSource().SyncFromOtherObj(item)).ToList();
        }

        public void Dispose ()
        {
        }
    }
}