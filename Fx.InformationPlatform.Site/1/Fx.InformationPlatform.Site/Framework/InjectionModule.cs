using Ninject.Modules;

namespace Fx.InformationPlatform.Site.Framework
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Fx.Domain.Account.IService.IAccountService>().To<Fx.Domain.Account.UserAccountService>();
        }
    }
}