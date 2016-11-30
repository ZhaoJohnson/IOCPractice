using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeModel;

namespace IOCPracticeInterface.IDAL
{
    public interface IMenuDataEngine<T> : IDataEngine<T>
        where T : MenuModel
    {
        IList<MenuModel> GetMenuModelsByParentId(int parentId);
        IList<MenuModel> GetMenuModelsByMenuName(string name);
        bool RemoveMenu(int menuid);
    }
}