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
    public class UserMenuMappingDataEngine : BasicDataEngine<UserMenuMappingModel, UserMenuMapping>, IUserMenuMappingDataEngine<UserMenuMappingModel>
    {
        protected UserMenuMappingDAO<UserMenuMapping> UserMenuMappingDAO => new UserMenuMappingDAO<UserMenuMapping>();
        public IList<UserMenuMappingModel> GetDataByUserId(int userid)
        {
            List<UserMenuMappingModel> resultList=new List<UserMenuMappingModel>();
            foreach (var single in UserMenuMappingDAO.GetUserMenuMappingsByUserId(userid).ToList())
            {
                resultList.Add(new UserMenuMappingModel().SyncFromOtherObj(single));
            }
            return resultList;
        }

        public IList<UserMenuMappingModel> GetDataByMenuId(int menuid)
        {
            List<UserMenuMappingModel> resultList = new List<UserMenuMappingModel>();
            foreach (var single in UserMenuMappingDAO.GetUserMenuMappingsByMenuId(menuid).ToList())
            {
                resultList.Add(new UserMenuMappingModel().SyncFromOtherObj(single));
            }
            return resultList;
        }

        public bool RemoveDataByUserId(int userid)
        {
            var usermenus = UserMenuMappingDAO.GetUserMenuMappingsByUserId(userid);
            UserMenuMappingDAO.MappingDb.RemoveRange(usermenus);
            return !UserMenuMappingDAO.GetUserMenuMappingsByUserId(userid).Any();
        }

        public bool RemoveDataByMenuId(int menuid)
        {
            throw new NotImplementedException();
        }
    }
}