using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeBusiness;
using IOCPracticeDAL;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeDAL.RetrunDataEngine;
using IOCPracticeInterface;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPractice
{
    internal class Program
    {
        private static void Main ( string[] args )
        {
            try
            {
                var con = IOCBusiness.star ();
                IOCRegisterDAL dal = new IOCRegisterDAL (con);
                var newuser = dal.userEngine.AddEntity (new UserModel
                {
                    Name = "test",
                    Account = "123",
                    CompanyId = 2,
                    CompanyName = "testcompany",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Email = "test@126.com",
                    LastLoginTime = DateTime.Now,
                    LastModifierId = -1,
                    LastModifyTime = DateTime.Now,
                    Mobile = "13987654321",
                    Password = "123456789",
                    State = 1,
                    UserType = 3
                });
                dal.userEngine.QuerySingle (newuser.Id);
                var partone = dal.userEngine.OffSetData (5, 1);
                var company = dal.companyEngine.OffSetData (5, 1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}