using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IOCPracticeAop.Attribute
{
    public interface IAfterLogHandlerAttribute
    {
        ICallHandler CreateHandler ( IUnityContainer container );
    }
}