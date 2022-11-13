using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interceptors
{
    public class MethodInterception:MethodInterceptionBaseAttirubute
    {

        protected virtual void OnBefore(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation) { }

        protected virtual void OnException(IInvocation invocation, Exception ex) { }
        protected virtual void OnSuccess (IInvocation ınvocation) { }
        public override void Intercept(IInvocation invocation)
        {

            bool issucces = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {

                issucces = false;
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (issucces)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);

        }

    }
}
