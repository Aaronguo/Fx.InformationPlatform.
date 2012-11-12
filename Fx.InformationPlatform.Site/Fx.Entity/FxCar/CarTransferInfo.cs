using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
    public class CarTransferInfo : CarBase
    {
        public int CarTransferInfoId { get; set; }

        public virtual List<TransferPicture> Pictures { get; set; }

        public CarTransferInfo()
        {          
            this.Pictures = new List<TransferPicture>();
        }
    }
}
