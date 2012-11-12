using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class BuyViewHouse
    {
        public string Title { get; set; }

        public int CatagroyId { get; set; }

        public decimal Price { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public int RoomNumber { get; set; }

        public bool Bill { get; set; }

        public bool HasFurniture { get; set; }

        public string Email { get; set; }

        public string Mark { get; set; }
    }
}