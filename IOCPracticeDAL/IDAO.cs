using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCPracticeDAL
{
    public interface IDAO:IDisposable
    {
        T Add<T>(T t) where T : class;



        T QuerySingle<T>(object objectKey) where T : class;


        T AddorUpdate<T>(T t) where T : class;


        /// <summary>
        /// lambda分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IList<T> SkipTable<T>(int pageSize, int pageIndex) where T : class;


        int GetCount<T>(Type t) where T : class;


        /// <summary>
        /// 经典分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IEnumerable<T> SkipData<T>(Type t, int pageSize, int pageIndex) where T : class;


        /// <summary>
        /// Need sql 2012
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IEnumerable<T> OffSetData<T>(Type t, int pageSize, int pageIndex) where T : class;

       
    }
}
