using System;
using System.Collections.Generic;
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
    }
}