using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;

namespace IOCPracticeDAL.IOCPracticeDAO
{
    public abstract class BasicDAO<T> : DbDAO<IOCPracticeDB>
        where T : class
    {
        protected IOCPracticeDB dbContext = new IOCPracticeDB ();

        public virtual T Add ( T t )
        {
            return ExecEntityJdData (ef => ef.Set<T> ().Add (t), true);
        }

        public virtual T QuerySingle ( object objectKey )
        {
            return ExecEntityJdData (ef => ef.Set<T> ().Find (objectKey));
        }

        public virtual T AddorUpdate ( T T )
        {
            return ExecEntityJdData (ef =>
             {
                 ef.Set<T> ().AddOrUpdate (T);
                 return ef.Set<T> ().Find (T);
             }, true);
        }

        /// <summary>
        /// lambda分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public virtual IList<T> SkipTable ( int pageSize, int pageIndex )
        {
            return ExecEntityJdData (ef =>
            {
                return ef.Set<T> ().Skip (( pageIndex - 1 ) * pageSize).Take (pageSize).ToList ();
            });
        }

        public virtual int GetCount ( Type t )
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
        public virtual IEnumerable<T> SkipData<T> ( Type t, int pageSize, int pageIndex )
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
        public virtual IEnumerable<T> OffSetData<T> ( Type t, int pageSize, int pageIndex )
        {
            return ExecEntityJdData (ef =>
             {
                 string strsql = string.Format ("SELECT * FROM {0} ORDER BY Id OFFSET ({1} -1) * {2} ROWS FETCH NEXT {2} ROWS ONLY; ;", t.Name, pageIndex, pageSize);
                 return ef.Database.SqlQuery<T> (strsql, new object[] { null }).ToList ();
             });
        }

        public void Dispose ()
        {
        }
    }
}