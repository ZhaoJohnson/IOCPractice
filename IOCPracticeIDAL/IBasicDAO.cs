using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCPracticeIDAL
{
    public interface IBasicDAO<T> : IDisposable
        where T : class
    {
        T Add(T t);

        T QuerySingle(object objectKey);

        T AddorUpdate(T T);

        IList<T> SkipTable(int pageSize, int pageIndex);

        int GetCount(Type t);

        IEnumerable<T> SkipData<T>(Type t, int pageSize, int pageIndex);

        IEnumerable<T> OffSetData<T>(Type t, int pageSize, int pageIndex);
    }
}