﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;
using IOCPracticeIDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL.IOCPracticeDAO
    {
    public class UserDAO : BasicDAO<UserModel>,IUserDAO
        {
        }
    }