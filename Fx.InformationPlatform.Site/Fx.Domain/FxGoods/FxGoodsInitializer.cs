using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class FxGoodsInitializer : DropCreateDatabaseAlways<FxGoodsContext>
    {
        protected override void Seed(FxGoodsContext context)
        {
            base.Seed(context);

            var goods = new List<CarPublishInfo>() { 
                new CarPublishInfo(){
                    PublishTitle="三星i9300手机，全新港版，未拆封，带发票，急转",
                    Price=100,
                    Mark="Mark1",
                    PublishUserEmail="117822597@163.com"                   
                },
                new CarPublishInfo(){
                    PublishTitle="摩托罗拉xt502 自用 无拆机 无暗病 7成新",
                    Price=1200,
                    Mark="Mark2",
                    PublishUserEmail="chen27468@163.com"
                },
                new CarPublishInfo(){
                    PublishTitle="出售MB502，安卓全键盘手机",
                    Price=1020,
                    Mark="Mark3",
                    PublishUserEmail="abc@163.com"
                },
                new CarPublishInfo(){
                    PublishTitle="s8新行货里程碑3",
                    Price=14500,
                    Mark="Mark4",
                    PublishUserEmail="jerry@163.com"
                },
                new CarPublishInfo(){
                    PublishTitle="自用里程碑1代",
                    Price=1600,
                    Mark="Mark5",
                    PublishUserEmail="chenzj@163.com"
                },
            };


            goods.ForEach(r => context.CarPublishInfos.Add(r));
            context.SaveChanges();
        }
    }
}
