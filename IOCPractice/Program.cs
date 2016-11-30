using System;
using System.Collections.Generic;
using IOCPracticeBusiness;
using IOCPracticeModel;

namespace IOCPractice
{
    internal class Program
    {
        private static void Main ( string[] args )
        {
            try
            {
                #region IOC初始化
                var con = IOCBusiness.star ();
                IOCRegisterDAL dal = new IOCRegisterDAL (con);
                #endregion

                #region 创建测试数据  
                //a.增用户
                foreach (UserModel userModel in createdUserData())
                {
                    dal.userEngine.AddEntity(userModel);
                }
                //b.增菜单
                createMenuModels(dal);
                #endregion

                #region

                #endregion

                var partone = dal.userEngine.OffSetData (5, 1);
                var company = dal.companyEngine.OffSetData (5, 1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        static List<UserModel> createdUserData()
        {
            List<UserModel> result=new List<UserModel>();
            for (int i = 1; i < 20; i++)
            {
                Random random=new Random();

                result.Add(new UserModel()
                {
                    Name = "测试用户"+i,
                    Account = i.ToString("000"),
                    CompanyId = random.Next(1, 6),
                    CompanyName = "testcompany",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Email = i.ToString()+"test"+"@126.com",
                    LastLoginTime = DateTime.Now,
                    LastModifierId = -1,
                    LastModifyTime = DateTime.Now,
                    Mobile = "13987654321",
                    Password = "123456789",
                    State = 1,
                    UserType = 3
                });
            }
            return result;
        }
        /// <summary>
        /// Menu表首先应该取消的自增长，否则不利于编号与路径逻辑
        /// </summary>
        /// <returns></returns>
        static void createMenuModels(IOCRegisterDAL dal)
        {
            int MarketorderId = 1001;
            MenuModel Marketorder = new MenuModel()
            {
                Id = MarketorderId,
                ParentId = 1,
                CreateTime = DateTime.Now,
                CreatorId = -1,
                Name = "销售订单管理",
                Description = "市场销售订单管理",
                LastModifierId = -1,
                LastModifyTime = DateTime.Now,
                Url = "/Order/Market",
                SourcePath = "root/1/" + MarketorderId,
                Sort = 200,
                MenuLevel = 2
            };
            dal.menuEngine.AddEntity(Marketorder);
            int passwordUserid = 6001;
            MenuModel passwordUser = new MenuModel()
            {
                Id = passwordUserid,
                ParentId = 6,
                CreateTime = DateTime.Now,
                CreatorId = -1,
                Name = "密码管理",
                Description = "设置及重置密码",
                LastModifierId = -1,
                LastModifyTime = DateTime.Now,
                Url = "/User/Password",
                SourcePath = "root/6/"+ passwordUserid,
                Sort = 200,
                MenuLevel = 2
            };
            dal.menuEngine.AddEntity(passwordUser);
            int RoleUserid = 6002;
            MenuModel RoleUser = new MenuModel()
            {
                Id = RoleUserid,
                ParentId = 6,
                CreateTime = DateTime.Now,
                CreatorId = -1,
                Name = "用户角色配置",
                Description = "设置及重置密码",
                LastModifierId = -1,
                LastModifyTime = DateTime.Now,
                Url = "/User/Password",
                SourcePath = "root/6/"+RoleUserid, 
                Sort = 200,
                MenuLevel = 2
            };
            dal.menuEngine.AddEntity(RoleUser);

        }

        static void createUserMenumapping(IOCRegisterDAL dal)
        {
            UserMenuMappingModel m1 = new UserMenuMappingModel()
            {
                //MenuId = 
            };
        }
    }
}