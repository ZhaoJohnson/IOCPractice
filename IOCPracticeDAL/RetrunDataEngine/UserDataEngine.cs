using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using IOCPracticeCommon.ObjectExtensions;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.RetrunDataEngine
{
    public class UserDataEngine : BasicDataEngine<UserModel, User>, IUserDataEngine<UserModel>
    {
        protected UserDAO<User> UserDAO => new UserDAO<User> ();

        public bool RemoveUser(int userid)
        {
            var removeUser= UserDAO.QuerySingle<User>(userid);
            if (removeUser == null) return true;
            UserDAO.UserDb.Remove(removeUser);
            var result = UserDAO.QuerySingle<User>(removeUser.Id);
            return result == null;
        }

    }
}