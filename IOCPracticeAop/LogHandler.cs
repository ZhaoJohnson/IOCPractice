using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeModel;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IOCPracticeAop
{
    public class LogHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke ( IMethodInvocation input, GetNextHandlerDelegate getNext )
        {
            UserModel user = input.Inputs[0] as UserModel;
            string message = string.Format ("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
            Console.WriteLine ("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
            return getNext () (input, getNext);
        }
    }
}