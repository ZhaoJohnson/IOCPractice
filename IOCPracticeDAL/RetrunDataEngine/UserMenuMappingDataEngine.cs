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
    public class UserMenuMappingDataEngine : BasicDataEngine<UserMenuMappingModel, UserMenuMapping>, IUserMenuMappingDataEngine<UserMenuMappingModel>
    {
    }
}