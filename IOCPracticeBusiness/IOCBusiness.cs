using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeInterface;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace IOCPracticeBusiness
{
    public static class IOCBusiness
    {
        public static IUnityContainer star ()
        {
            #region IOC 容器注入

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap ();
            fileMap.ExeConfigFilename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory + "MapSetting\\IOCSetting.xml");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration (fileMap, ConfigurationUserLevel.None);
            //UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection (UnityConfigurationSection.SectionName);

            #endregion IOC 容器注入

            #region 注册DLL

            IUnityContainer container = new UnityContainer ();
            //后部分可以通过配置文件实现扩展与管理
            section.Configure (container, "DemonIOCPracticeDAOContainer");
            return container;

            #endregion 注册DLL

            #region 实例化对象

            //IUserDataEngine<UserModel> userEngine = container.Resolve<IUserDataEngine<UserModel>> ();
            //ICompanyDataEngine<CompanyModel> companyEngine = container.Resolve<ICompanyDataEngine<CompanyModel>> ();
            //IMenuDataEngine<MenuModel> menuEngine = container.Resolve<IMenuDataEngine<MenuModel>> ();
            //IUserMenuMappingDataEngine<UserMenuMappingModel> userMenuEngine = container.Resolve<IUserMenuMappingDataEngine<UserMenuMappingModel>> ();

            #endregion 实例化对象

            #region 实现业务

            //var user2 = userEngine.QuerySingle (2);

            #endregion 实现业务
        }
    }
}