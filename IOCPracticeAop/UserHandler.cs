using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;//InterceptionExtension扩展

namespace IOCPracticeAop
{
    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke ( IMethodInvocation input, GetNextHandlerDelegate getNext )
        {
            UserModel user = input.Inputs[0] as UserModel;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn (new Exception ("密码长度不能小于10位"));
            }
            Console.WriteLine ("参数检测无误");

            IMethodReturn methodReturn = getNext () (input, getNext);

            //Console.WriteLine("已完成操作");

            return methodReturn;
        }
    }
}