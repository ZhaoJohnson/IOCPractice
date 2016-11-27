using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOCPracticeBusiness
{
    public class IOCService : IDisposable
    {
        public enum LifeTimeOptions
        {
            TransientLifeTimeOption,
            ContainerControlledLifeTimeOption
        }

        public class ResolvedTypeWithLifeTimeOptions
        {
            public Type ResolvedType { get; set; }
            public LifeTimeOptions LifeTimeOption { get; set; }
            public object InstanceValue { get; set; }

            public ResolvedTypeWithLifeTimeOptions(Type resolvedType)
            {
                ResolvedType = resolvedType;
                LifeTimeOption = LifeTimeOptions.TransientLifeTimeOption;
                InstanceValue = null;
            }

            public ResolvedTypeWithLifeTimeOptions(Type resolvedType, LifeTimeOptions lifeTimeOption)
            {
                ResolvedType = resolvedType;
                LifeTimeOption = lifeTimeOption;
                InstanceValue = null;
            }
        }

        private Dictionary<Type, ResolvedTypeWithLifeTimeOptions>
            iocMap = new Dictionary<Type, ResolvedTypeWithLifeTimeOptions>();

        public void Register<T1, T2>()
        {
            Register<T1, T2>(LifeTimeOptions.TransientLifeTimeOption);
        }

        public void Register<T1, T2>(LifeTimeOptions lifeTimeOption)
        {
            if (iocMap.ContainsKey(typeof(T1)))
            {
                throw new Exception(string.Format("Type {0} already registered.", typeof(T1).FullName));
            }
            ResolvedTypeWithLifeTimeOptions targetType = new ResolvedTypeWithLifeTimeOptions(typeof(T2),
                                                                                             lifeTimeOption);
            iocMap.Add(typeof(T1), targetType);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            // Find the registered type for typeToResolve
            if (!iocMap.ContainsKey(typeToResolve))
                throw new Exception(string.Format("Can't resolve {0}.Type is not registered.", typeToResolve.FullName));

            ResolvedTypeWithLifeTimeOptions resolvedType = iocMap[typeToResolve];

            // Step-1: If LifeTimeOption is ContainerControlled and there is
            //already an instance created then return the created instance.
            if (resolvedType.LifeTimeOption ==
                LifeTimeOptions.ContainerControlledLifeTimeOption &&
                resolvedType.InstanceValue != null)
                return resolvedType.InstanceValue;

            // Try to construct the object
            // Step-2: find the constructor
            //(ideally first constructor if multiple constructors present for the type)
            ConstructorInfo ctorInfo = resolvedType.ResolvedType.GetConstructors().First();

            // Step-3: find the parameters for the constructor and try to resolve those
            List<ParameterInfo> paramsInfo = ctorInfo.GetParameters().ToList();
            List<object> resolvedParams = new List<object>();
            foreach (ParameterInfo param in paramsInfo)
            {
                Type t = param.ParameterType;
                object res = Resolve(t);
                resolvedParams.Add(res);
            }

            // Step-4: using reflection invoke constructor to create the object
            object retObject = ctorInfo.Invoke(resolvedParams.ToArray());

            resolvedType.InstanceValue = retObject;

            return retObject;
        }

        public void Dispose()
        {
        }
    }
}