using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeInterface;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeInterface
{
    public interface ICompanyDataEngine<T> : IDataEngine<T>
        where T : CompanyModel
    {
    }
}