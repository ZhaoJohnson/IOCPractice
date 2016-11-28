using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class MenuDataEngine<TModel> : BasicDataEngine<TModel, Menu>, IMenuDataEngine<TModel>
        where TModel : MenuModel, new()
    {
    }
}