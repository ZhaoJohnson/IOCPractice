using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCPracticeInterface.IDAL
{
    /// <summary>
    /// 改为使用IDataEngine 出口方案
    /// </summary>
    public interface IRetrunDataEngine
    {
        T Add<T>(T model) where T : class, new();

        T QuerySingle<T>(object objectKey) where T : class, new();



        T AddorUpdate<T>(T model) where T : class, new();



        IList<T> SkipTable<T>(int pageSize, int pageIndex) where T : class, new();



        int GetCount();


        IEnumerable<T> SkipData<T>(int pageSize, int pageIndex) where T : class, new();


        IEnumerable<T> OffSetData<T>(int pageSize, int pageIndex) where T : class, new();


    }
}
