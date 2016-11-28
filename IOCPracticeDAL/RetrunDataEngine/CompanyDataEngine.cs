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
    public class CompanyDataEngine : BaseDataEngine
    {
        public CompanyDataEngine()
        {
            BaseDao=new CompanyDAO<Company>();
        }

        public override T Add<T>(T model) 
        {
            return base.Add(model);
        }
    }
}
