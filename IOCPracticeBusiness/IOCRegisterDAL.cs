using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;
using Microsoft.Practices.Unity;

namespace IOCPracticeBusiness
{
    /// <summary>
    /// 封装IOC注入的接口，便于统一调用
    /// </summary>
    public class IOCRegisterDAL
    {
        public IOCRegisterDAL ( IUnityContainer _container )
        {
            this.container = _container;
        }

        protected IUnityContainer container;
        public IUserDataEngine<UserModel> userEngine => container.Resolve<IUserDataEngine<UserModel>> ();
        public ICompanyDataEngine<CompanyModel> companyEngine => container.Resolve<ICompanyDataEngine<CompanyModel>> ();
        public IMenuDataEngine<MenuModel> menuEngine => container.Resolve<IMenuDataEngine<MenuModel>> ();
        public IUserMenuMappingDataEngine<UserMenuMappingModel> userMenuEngine => container.Resolve<IUserMenuMappingDataEngine<UserMenuMappingModel>> ();
    }
}