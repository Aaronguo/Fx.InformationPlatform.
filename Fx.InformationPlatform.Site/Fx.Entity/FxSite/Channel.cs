﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 频道
    /// </summary>
    public class Channel : IAction
    {
        public Channel()
        {
            this.ChannelLists = new List<ChannelList>();            
        }

        public int ChannelId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 频道简介
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<ChannelList> ChannelLists { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RoutePars { get; set; }


        public virtual int Sorted { get; set; }

    }
}
