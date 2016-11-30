using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;

namespace IOCPracticeDAL.IOCPracticeDAO
{
    public class BasicDAO : DbDAO<IOCPracticeDB>, IDAO

    {
        protected IOCPracticeDB dbContext = new IOCPracticeDB ();

        public virtual T Add<T> ( T t ) where T : class
        {
            return ExecEntityJdData (ef => ef.Set<T> ().Add (t), true);
        }

       
        public IList<T> GetData<T>() where T : class
        {
            return ExecEntityJdData(ef => ef.Set<T>().ToList());
        }

        public virtual T QuerySingle<T> ( object objectKey ) where T : class
        {
            return ExecEntityJdData (ef => ef.Set<T> ().Find (objectKey));
        }
        
        public virtual T AddorUpdate<T> ( T t ) where T : class
        {
            return ExecEntityJdData (ef =>
             {
                 ef.Set<T> ().AddOrUpdate (t);
                 return ef.Set<T> ().Find (t);
             }, true);
        }

        public T GetRandomData<T>(Type t) where T : class
        {
            return ExecEntityJdData(ef =>
           {
               string strsql = string.Format("select TOP 1 * from dbo.[{0}] ORDER BY NEWID()", t.Name);
               return ef.Database.SqlQuery<T>(strsql, new object[] { null }).ToList().FirstOrDefault();
           }, true);
        }

        /// <summary>
        /// lambda分页  有待调整
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public virtual IList<T> SkipTable<T> ( int pageSize, int pageIndex ) where T : class
        {
            return ExecEntityJdData (ef =>
            {
                return ef.Set<T> ().OrderBy (p => p).Skip (( pageIndex - 1 ) * pageSize).Take (pageSize).ToList ();
            });
        }

        public virtual int GetCount<T> ( Type t ) where T : class
        {
            return ExecEntityJdData (ef =>
             {
                 string strsql = string.Format ("select count(*) from {0}", t.Name);
                 return ef.Database.SqlQuery<int> (strsql, new object[] { null }).FirstOrDefault ();
             });
        }

        /// <summary>
        /// 经典分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> SkipData<T> ( Type t, int pageSize, int pageIndex ) where T : class
        {
            return ExecEntityJdData (ef =>
             {
                 string strsql = string.Format ("SELECT top {2} * FROM {0} WHERE id>{1};", t.Name, pageSize * Math.Max (0, pageIndex - 1), pageSize);
                 return ef.Database.SqlQuery<T> (strsql, new object[] { null }).ToList ();
             });
        }

        /// <summary>
        /// Need sql 2012
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> OffSetData<T> ( Type t, int pageSize, int pageIndex ) where T : class
        {
            return ExecEntityJdData (ef =>
             {
                 string strsql = string.Format ("SELECT * FROM dbo.[{0}] ORDER BY Id OFFSET ({1} -1) * {2} ROWS FETCH NEXT {2} ROWS ONLY; ;", t.Name, pageIndex, pageSize);
                 return ef.Database.SqlQuery<T> (strsql, new object[] { null }).ToList ();
             });
        }

        public void Dispose ()
        {
        }
    }
}