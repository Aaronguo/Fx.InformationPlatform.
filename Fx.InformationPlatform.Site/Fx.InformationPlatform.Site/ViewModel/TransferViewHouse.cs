using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class TransferViewHouse
    {
        public string Title { get; set; }

        public int CatagroyId { get; set; }

        public decimal Price { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public string PostCode { get; set; }

        public string RoadName { get; set; }

        public int RoomNumber { get; set; }

        public bool Bill { get; set; }

        public bool HasFurniture { get; set; }

        public string Email { get; set; }

        public string Mark { get; set; }

        public List<TransferPicture> FaceFiles { get; set; }

        public List<TransferPicture> OtherFiles { get; set; }

        public List<TransferPicture> BadFiles { get; set; }

        public TransferViewHouse()
        {
            FaceFiles = new List<TransferPicture>();
            OtherFiles = new List<TransferPicture>();
            BadFiles = new List<TransferPicture>();
        }
    }
}