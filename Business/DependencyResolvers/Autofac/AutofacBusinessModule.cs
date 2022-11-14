using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Repositories.AuthRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Business.Utilities;
using Core.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Services.AddScoped<IOperationClaimService, OperationClaimManeger>();
            //builder.Services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
            builder.RegisterType<OperationClaimManeger>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManeger>().As<IUserService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();
            builder.RegisterType<FileManeger>().As<IFileService>();

            builder.RegisterType<UserOperationClaimManeger>().As<IUserOperationClaimService>();
            builder.RegisterType<AuthManeger>().As<IAuthService>();
            var assembly=System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions() { Selector = new AspectInterceptorSelector()}).SingleInstance() ; //aspect kullandığımı programa söylüyorum autofac extras dynamicproxy pakatini kur 


        }
    }
}
