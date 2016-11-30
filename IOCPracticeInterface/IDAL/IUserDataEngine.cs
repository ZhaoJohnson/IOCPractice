using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCPracticeModel;

namespace IOCPracticeInterface.IDAL
{
    public interface IUserDataEngine<T> : IDataEngine<T>
        where T : UserModel
    {
        bool RemoveUser(int userid);
    }
}