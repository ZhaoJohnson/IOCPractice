using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace IOCPracticeBusiness
{
    public class BaseBusiness
    {
        public void star ()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap ();
            fileMap.ExeConfigFilename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory + "MapSetting\\IOCSetting.xml");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration (fileMap, ConfigurationUserLevel.None);
            //UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection (UnityConfigurationSection.SectionName);

            IUnityContainer container = new UnityContainer ();
            section.Configure (container, "DemonIOCPracticeDAOContainer");
            IUserDataEngine userEngine = container.Resolve<IUserDataEngine> ();
            var ww = userEngine.QuerySingle (2);
            //IBasicDAO<UserModel> iBaseServie = container.Resolve<IBasicDAO<UserModel>> ();
            //var s = iBaseServie.SkipTable (1, 1);
        }

        private TResult GenerateResult<Tin, TResult> ()
        {
            using (var ioc = new IOCService ())
            {
                return default (TResult);
            }
        }
    }
}