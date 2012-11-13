﻿using System.Collections.Generic;
using Fx.Entity;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class TransferViewCar
    {
        public string Title { get; set; }

        public int CatagroyId { get; set; }

        public decimal Price { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public int CarYear { get; set; }

        public int CarMileage { get; set; }

        public string Email { get; set; }

        public string Mark { get; set; }

        public List<TransferPicture> FaceFiles { get; set; }

        public List<TransferPicture> OtherFiles { get; set; }

        public List<TransferPicture> BadFiles { get; set; }

        public TransferViewCar()
        {
            FaceFiles = new List<TransferPicture>();
            OtherFiles = new List<TransferPicture>();
            BadFiles = new List<TransferPicture>();
        }
    }
}