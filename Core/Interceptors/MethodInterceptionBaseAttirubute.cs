using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interceptors
{
    [AttributeUsage(AttributeTargets.Class |AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptionBaseAttirubute : Attribute,IInterceptor
    {  //custle.core dll kuracan
        public virtual void Intercept(IInvocation invocation)
        {

        }
          
    }

   
}
