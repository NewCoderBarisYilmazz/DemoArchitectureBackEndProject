using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
           var classAttirubutes=type.GetCustomAttributes<MethodInterceptionBaseAttirubute>(true).ToList(); //attirubutleri yakaladım
            var methodAttirubutes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttirubute>(true); //methodlaclası birleştirdim
            classAttirubutes.AddRange(methodAttirubutes);
            return classAttirubutes.ToArray();
        }
    }
}
