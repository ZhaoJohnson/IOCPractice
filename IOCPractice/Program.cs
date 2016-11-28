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
                //IDataEngine<UserModel> cd = new UserDataEngine ();

                //var ee = cd.OffSetData (1, 1);
                // BaseDataEngine<CompanyModel> engine=new CompanyDataEngine<CompanyModel>();
                // engine.Add<CompanyModel>(new CompanyModel());
                //UserDataEngine uEngine = new UserDataEngine ();
                //var re = uEngine.OffSetData (10, 1);
                //  IBasicDAO<UserModel> udao = new UserDAO ();
                //var e = udao.QuerySingle (1);
                BaseBusiness bb = new BaseBusiness ();
                bb.star ();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}