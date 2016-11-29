using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeDAL.Entity;
using IOCPracticeDAL.RetrunDataEngine;
using IOCPracticeInterface;
using IOCPracticeInterface.IDAL;
using IOCPracticeModel;

namespace IOCPracticeDAL
{
    public class DALSerivec : IDALService
    {
        public DALSerivec ()
        {
        }

        protected CompanyDataEngine<CompanyModel, Company> CompanyDataEngine => new CompanyDataEngine<CompanyModel, Company> ();

        /// <summary>
        /// 基于接口，提供功能
        /// </summary>
        /// <typeparam name="TGenericServices"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="serviceInstance"></param>
        /// <param name="callServiceFn"></param>
        /// <returns></returns>
        private static TResult CallService<TGenericServices, TResult> (
          /*Input */ TGenericServices serviceInstance,
          /*Output*/Func<TGenericServices, TResult> callServiceFn )
          where TGenericServices : IDataEngine
        {
            using (var service = serviceInstance)
            {
                //Return call Engine
                return callServiceFn (service);
            }
        }
    }
}