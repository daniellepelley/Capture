using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Capture.Core
{
    public class MonitorInterceptor : IInterceptor
    {
        public List<IInvocation> List { get; private set; }

        public MonitorInterceptor()
        {
            List = new List<IInvocation>();
        }

        public void Intercept(IInvocation invocation)
        {
            List.Add(invocation);
            invocation.Proceed();
        }
    }

    public class MonitorInterceptor<T> : MonitorInterceptor where T : class
    {
        public T Object { get; private set; }

        public MonitorInterceptor(T instance)
        {
            Object = new ProxyGenerator().CreateInterfaceProxyWithTarget(instance, this);
        }
    }
}
