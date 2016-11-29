using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCPracticeInterface.IDAL
{
    public interface IDataEngine<T> : IDisposable
    {
        T AddEntity ( T tSource );

        T AddorUpdate ( T model );

        IEnumerable<T> OffSetData ( Int32 pageSize, Int32 pageIndex );

        T QuerySingle ( Object objectKey );

        //IList<T> SkipTable ( Int32 pageSize, Int32 pageIndex );
    }
}