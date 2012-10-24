using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity
{
    interface IAction
    {
        /// <summary>
        /// MVC控制器名称 如一个Car频道 那么设置其控制器是Car
        /// </summary>
        string ControllerName { get; set; }

        /// <summary>
        /// MVC Action
        /// </summary>
        string ActionName { get; set; }

        /// <summary>
        /// MVC Route参数
        /// </summary>
        string RoutePars { get; set; }

        //string HtmlAttributes { get; set; }
    }
}
