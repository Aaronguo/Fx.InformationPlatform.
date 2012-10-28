namespace Fx.InformationPlatform.Site.Framework
{
    public abstract class ChannelLocation
    {
        protected string ControllerName { get; private set; }

        protected string ActionName { get; private set; }

        protected string RoutePars { get; private set; }
    }
}