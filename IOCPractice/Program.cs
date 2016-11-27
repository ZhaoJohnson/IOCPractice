using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeBusiness;
using IOCPracticeDAL.IOCPracticeDAO;
using IOCPracticeDAL.RetrunDataEngine;

namespace IOCPractice
{
    internal class Program
    {
        private static void Main ( string[] args )
        {
            try
            {
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