using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class BuyViewGoods
    {
        public string Title { get; set; }

        public int CatagroyId { get; set; }

        public decimal Price { get; set; }

        public bool IsChangeGoods { get; set; }

        /// <summary>
        /// 想要交互物品的信息
        /// </summary>
        public string ChangeGoodsMsg { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public int GoodConditionId { get; set; }

        /// <summary>
        /// 物品新旧程度相关信息
        /// </summary>
        public string GoodConditonMsg { get; set; }

        public List<BuyPicture> FaceFiles { get; set; }

        public List<BuyPicture> OtherFiles { get; set; }

        public List<BuyPicture> BadFiles { get; set; }

        public string Email { get; set; }

        public string Mark { get; set; }

        public BuyViewGoods()
        {
            FaceFiles = new List<BuyPicture>();
            OtherFiles = new List<BuyPicture>();
            BadFiles = new List<BuyPicture>();
        }
    }
}