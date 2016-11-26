using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeBusiness;

namespace IOCPractice
    {
    internal class Program
        {
        private static void Main ( string[] args )
            {
            try
                {
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