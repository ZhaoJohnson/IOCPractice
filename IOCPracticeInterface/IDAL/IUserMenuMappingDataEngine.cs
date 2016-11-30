using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeModel;

namespace IOCPracticeInterface.IDAL
{
    public interface IUserMenuMappingDataEngine<T> : IDataEngine<T>
        where T : UserMenuMappingModel
    {
        IList<UserMenuMappingModel> GetDataByUserId(int userid);
        IList<UserMenuMappingModel> GetDataByMenuId(int menuid);
        bool RemoveDataByUserId(int userid);
        bool RemoveDataByMenuId(int menuid);
    }
}