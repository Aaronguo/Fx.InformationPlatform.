using System.Web.Mvc;
using Elmah;

namespace Fx.InformationPlatform.Site.Framework
{
    /// <summary>
    /// 处理因自定义customErrors节点 导致Elmah不工作的问题
    /// 需要注册到Goabal中
    /// http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute/5936867#5936867
    /// other information:
    /// http://dotnetslackers.com/articles/aspnet/ErrorLoggingModulesAndHandlers.aspx
    /// </summary>
    public class ElmahHandledErrorLoggerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log only handled exceptions, because all other will be caught by ELMAH anyway.
            if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}