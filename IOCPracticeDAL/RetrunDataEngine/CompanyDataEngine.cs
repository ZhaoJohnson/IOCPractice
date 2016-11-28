using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeInterface;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class CompanyDataEngine : BasicDataEngine<CompanyModel, Company>, ICompanyDataEngine<CompanyModel>

    {
    }
}