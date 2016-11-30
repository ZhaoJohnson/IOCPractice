using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class MenuDataEngine : BasicDataEngine<MenuModel, Menu>, IMenuDataEngine<MenuModel>

    {
        protected MenuDAO<Menu> MenuDao=>new MenuDAO<Menu>();

        public IList<MenuModel> GetMenuModelsByParentId(int parentId)
        {
            List<MenuModel> resultList=new List<MenuModel>();
            foreach (var single in MenuDao.MenuDb.Where(p => p.ParentId == parentId))
            {
             resultList.Add(new MenuModel().SyncFromOtherObj(single));   
            }

            return resultList;
        }

        public IList<MenuModel> GetMenuModelsByMenuName(string name)
        {
            List<MenuModel> resultList = new List<MenuModel>();
            foreach(var single in MenuDao.MenuDb.Where(p => p.Name.Contains(name)))
            {
                resultList.Add(new MenuModel().SyncFromOtherObj(single));
            }
            return resultList;
        }

        public bool RemoveMenu(int menuid)
        {
            var removeMenu = MenuDao.QuerySingle<Menu>(menuid);
            if (removeMenu == null) return true;
            MenuDao.MenuDb.Remove(removeMenu);
            var result = MenuDao.QuerySingle<Menu>(removeMenu.Id);
            return result == null;
        }
    }
}