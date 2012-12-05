using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxSite;

namespace Fx.Domain
{
    public class SiteInitializer : CreateDatabaseIfNotExists<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            base.Seed(context);

            #region 地区城市初始化 邮编!!
            var areas = new List<Area>() { 
                new Area(){
                    AreaName="East Midlands",
                    Sorted=1,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Leicester",
                         Sorted=1
                       },
                       new City(){
                         CityName="Loughborough",
                         Sorted=2
                       },
                       new City(){
                         CityName="Nottingham",
                         Sorted=3
                       },
                       new City(){
                         CityName="Derby",
                         Sorted=4
                       },
                       new City(){
                         CityName="Northampton",
                         Sorted=5
                       }
                    }
                },
                new Area(){
                    AreaName="East of England",
                    Sorted=2,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Cambridge",
                         Sorted=1
                       },
                       new City(){
                         CityName="Chelmsford",
                         Sorted=2
                       },
                       new City(){
                         CityName="Cranfield",
                         Sorted=3
                       },
                       new City(){
                         CityName="Norwich",
                         Sorted=4
                       },
                       new City(){
                         CityName="Ipswich",
                         Sorted=5
                       },
                       new City(){
                         CityName="Luton",
                         Sorted=6
                       },
                       new City(){
                         CityName="Colchester",
                         Sorted=7
                       },
                       new City(){
                         CityName="Hatfield",
                         Sorted=8
                       },
                       new City(){
                         CityName="其他",
                         Sorted=9
                       }
                    }
                },
                new Area(){
                    AreaName="Greater London",
                    Sorted=3,
                    Cities=new List<City>(){
                       new City(){
                         CityName="City of London",
                         Sorted=1
                       },
                       new City(){
                         CityName="City of Westminster",
                         Sorted=2
                       },
                       new City(){
                         CityName="Kensington and Chelsea",
                         Sorted=3
                       },
                       new City(){
                         CityName="Hammersmith and Fulham",
                         Sorted=4
                       },
                       new City(){
                         CityName="Wandsworth",
                         Sorted=5
                       },
                       new City(){
                         CityName="Lambeth",
                         Sorted=6
                       },
                       new City(){
                         CityName="Southwark",
                         Sorted=7
                       },
                       new City(){
                         CityName="Tower Hamlets",
                         Sorted=8
                       },
                       new City(){
                         CityName="Hackney",
                         Sorted=9
                       },
                       new City(){
                         CityName="Islington",
                         Sorted=10
                       },
                       new City(){
                         CityName="Camden",
                         Sorted=11
                       },
                       new City(){
                         CityName="Brent",
                         Sorted=12
                       },
                       new City(){
                         CityName="Ealing",
                         Sorted=13
                       },
                       new City(){
                         CityName="Hounslow",
                         Sorted=14
                       },
                       new City(){
                         CityName="Richmond",
                         Sorted=15
                       },
                       new City(){
                         CityName="KingstonMerton",
                         Sorted=16
                       },
                       new City(){
                         CityName="Sutton",
                         Sorted=17
                       },
                       new City(){
                         CityName="Croydon",
                         Sorted=18
                       },
                       new City(){
                         CityName="Bromley",
                         Sorted=19
                       },
                       new City(){
                         CityName="Lewisham",
                         Sorted=20
                       },new City(){
                         CityName="Greenwich",
                         Sorted=21
                       },
                       new City(){
                         CityName="Bexley",
                         Sorted=22
                       },
                       new City(){
                         CityName="Havering",
                         Sorted=23
                       },
                       new City(){
                         CityName="Barking and Dagenham",
                         Sorted=24
                       },
                       new City(){
                         CityName="Redbridge",
                         Sorted=25
                       },
                       new City(){
                         CityName="Newham",
                         Sorted=26
                       },
                       new City(){
                         CityName="Waltham Forest",
                         Sorted=27
                       },
                       new City(){
                         CityName="Haringey",
                         Sorted=28
                       },
                       new City(){
                         CityName="Enfield",
                         Sorted=29
                       },
                       new City(){
                         CityName="Barnet",
                         Sorted=30
                       },
                       new City(){
                         CityName="Harrow",
                         Sorted=31
                       },
                       new City(){
                         CityName="Hillingdon",
                         Sorted=32
                       },
                    }
                },
                new Area(){
                    AreaName="North East England",
                    Sorted=4,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Durham",
                         Sorted=1
                       },
                       new City(){
                         CityName="Newcastle",
                         Sorted=2
                       },
                       new City(){
                         CityName="Sunderland",
                         Sorted=3
                       }
                    }
                },
                new Area(){
                    AreaName="North West England",
                    Sorted=5,
                    Cities=new List<City>(){
                      new City(){
                         CityName="Ormskirk",
                         Sorted=1
                       },
                       new City(){
                         CityName="Lancaster",
                         Sorted=2
                       },
                       new City(){
                         CityName="Liverpool",
                         Sorted=3
                       },
                       new City(){
                         CityName="Manchester",
                         Sorted=4
                       },
                       new City(){
                         CityName="Bolton",
                         Sorted=5
                       },
                       new City(){
                         CityName="Carlisle",
                         Sorted=6
                       },
                       new City(){
                         CityName="Chester",
                         Sorted=7
                       },
                       new City(){
                         CityName="Warrington",
                         Sorted=8
                       }
                    }
                },
                new Area(){
                    AreaName="South East England",
                    Sorted=6,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Buckingham",
                         Sorted=1
                       },
                       new City(){
                         CityName="Kent",
                         Sorted=2
                       },
                       new City(){
                         CityName="Surrey",
                         Sorted=3
                       },
                       new City(){
                         CityName="Henley-on-Thames",
                         Sorted=4
                       },
                       new City(){
                         CityName="Oxford",
                         Sorted=5
                       },
                       new City(){
                         CityName="Southampton",
                         Sorted=6
                       },
                       new City(){
                         CityName="Guildford",
                         Sorted=7
                       },
                       new City(){
                         CityName="Milton Keynes",
                         Sorted=8
                       },
                       new City(){
                         CityName="Brighton",
                         Sorted=9
                       },
                       new City(){
                         CityName="Chichester",
                         Sorted=10
                       },
                       new City(){
                         CityName="Portsmouth",
                         Sorted=11
                       },
                       new City(){
                         CityName="Reading",
                         Sorted=12
                       },
                       new City(){
                         CityName="Winchester",
                         Sorted=13
                       },
                    }
                },
                new Area(){
                    AreaName="South West England",
                    Sorted=7,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Bath",
                         Sorted=1
                       },
                       new City(){
                         CityName="Cornwall",
                         Sorted=1
                       },
                       new City(){
                         CityName="Bournemouth",
                         Sorted=1
                       },
                       new City(){
                         CityName="Cirencester",
                         Sorted=1
                       },
                       new City(){
                         CityName="Plymouth",
                         Sorted=1
                       },
                       new City(){
                         CityName="Bristol",
                         Sorted=1
                       },
                       new City(){
                         CityName="Exeter",
                         Sorted=1
                       },
                       new City(){
                         CityName="Cheltenham",
                         Sorted=1
                       },
                       new City(){
                         CityName="Chippenham",
                         Sorted=1
                       }
                    }
                },
                 new Area(){
                    AreaName="West Midlands",
                    Sorted=8,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Birmingham",
                         Sorted=1
                       },
                       new City(){
                         CityName="Coventry",
                         Sorted=2
                       },
                       new City(){
                         CityName="Keele",
                         Sorted=3
                       },
                       new City(){
                         CityName="Stoke on Trent",
                         Sorted=4
                       },
                       new City(){
                         CityName="Wolverhampton",
                         Sorted=5
                       },
                       new City(){
                         CityName="Worcester",
                         Sorted=6
                       }
                    }
                },
                 new Area(){
                    AreaName="Yorkshire and the Humber",
                    Sorted=9,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Lincoln",
                         Sorted=1
                       },
                       new City(){
                         CityName="Leeds",
                         Sorted=2
                       },
                       new City(){
                         CityName="Sheffield",
                         Sorted=3
                       },
                       new City(){
                         CityName="York",
                         Sorted=4
                       },
                       new City(){
                         CityName="Bradford",
                         Sorted=5
                       },
                       new City(){
                         CityName="Huddersfield",
                         Sorted=6
                       },
                       new City(){
                         CityName="Hull",
                         Sorted=7
                       },
                       new City(){
                         CityName="Scarborough",
                         Sorted=8
                       }
                    }
                },
                 new Area(){
                    AreaName="Soctland",
                    Sorted=10,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Edinburgh",
                         Sorted=1
                       },
                       new City(){
                         CityName="Glasgow",
                         Sorted=2
                       },
                       new City(){
                         CityName="Livingston",
                         Sorted=3
                       },
                       new City(){
                         CityName="Aberdeen",
                         Sorted=4
                       },
                       new City(){
                         CityName="Dundee",
                         Sorted=5
                       },
                       new City(){
                         CityName="St Andrews",
                         Sorted=6
                       },
                       new City(){
                         CityName="Stirling",
                         Sorted=7
                       },
                       new City(){
                         CityName="Inverness",
                         Sorted=8
                       },
                       new City(){
                         CityName="Paisley",
                         Sorted=9
                       }
                    }
                },
                 new Area(){
                    AreaName="Wales",
                    Sorted=11,
                    Cities=new List<City>(){
                       new City(){
                         CityName="Aberystwyth",
                         Sorted=1
                       },
                       new City(){
                         CityName="Bangor",
                         Sorted=2
                       },
                       new City(){
                         CityName="Cardiff",
                         Sorted=3
                       },
                       new City(){
                         CityName="Wrexham",
                         Sorted=4
                       },
                       new City(){
                         CityName="Swansea",
                         Sorted=5
                       },
                       new City(){
                         CityName="Carmarthen",
                         Sorted=6
                       },
                       new City(){
                         CityName="Pontypridd",
                         Sorted=7
                       },
                       new City(){
                         CityName="Lampeter",
                         Sorted=8
                       },
                       new City(){
                         CityName="Newport",
                         Sorted=9
                       }
                    }
                },
                 new Area(){
                    AreaName="Northern Irland",
                    Sorted=12,
                    Cities=new List<City>(){
                      new City(){
                         CityName="Belfast", 
                         Sorted=1
                       },
                       new City(){
                         CityName="其他",
                         Sorted=2
                       }
                    }
                },
            };
            #endregion
            areas.ForEach(r => context.Areas.Add(r));
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {

                throw ex;
            }

            #region 频道建立
            var channels = new List<Channel>() { 
                new Channel(){
                     ChannelName="物品交易",
                     Description="",
                     ControllerName="Goods",
                     ActionName="Index",
                     Sorted=1
                },
                new Channel(){
                     ChannelName="车辆交易",
                     Description="",
                     ControllerName="Car",
                     ActionName="Index",
                     Sorted=2
                },
                new Channel(){
                     ChannelName="租房信息",
                     Description="",
                     ControllerName="House",
                     ActionName="Index",
                     Sorted=3
                },
            };



            #region 物品交易
            var goodsList = new List<ChannelList>() { 
                new ChannelList(){
                     ChannelListName="数码产品",
                     Description="",
                     ControllerName=channels[0].ControllerName,
                     ActionName="Electronics",
                     Sorted=1,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="手机",
                            Sorted=1,
                            ActionName="Phone"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="电脑",
                            Sorted=2,
                            ActionName="Computer"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="数码摄像器材",
                            Sorted=3,
                            ActionName="DigitalCamera"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="电脑配件",
                            Sorted=4,
                            ActionName="ComputerAccessories"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="游戏机",
                            Sorted=5,
                            ActionName="PlayStations"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="游戏机配件",
                            Sorted=6,
                            ActionName="PSAccessories"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="手机配件",
                            Sorted=7,
                            ActionName="PhoneAccessories"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="其他",
                            Sorted=8,
                            ActionName="ElectronicsOther"
                         },
                     }
                },
                new ChannelList(){
                     ChannelListName="居家用品",
                     Description="",
                     ControllerName=channels[0].ControllerName,
                     ActionName="HomeSupplies",
                     Sorted=2,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="家具",
                            Sorted=1,
                            ActionName="Furniture"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="厨房家电",
                            Sorted=2,
                            ActionName="KitchenAppliances"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="视听家电",
                            Sorted=3,
                            ActionName="AudioAppliances"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="餐具/厨具",
                            Sorted=4,
                            ActionName="KitchenDinningWares"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="工艺品/摆设",
                            Sorted=5,
                            ActionName="Decoration"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="其他家电",
                            Sorted=6,
                            ActionName="OtherElectronics"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="运动器材",
                            Sorted=7,
                            ActionName="GymEquipment"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="单车",
                            Sorted=8,
                            ActionName="Bike"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="其他",
                            Sorted=9,
                            ActionName="HomeSuppliesOther"
                         },
                     }
                },
                new ChannelList(){
                     ChannelListName="衣服鞋包",
                     Description="",
                     ControllerName=channels[0].ControllerName,
                     ActionName="Fashion",
                     Sorted=3,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="衣服",
                            Sorted=1,
                            ActionName="Clothing"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="鞋子",
                            Sorted=2,
                            ActionName="Shoes"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="箱包",
                            Sorted=3,
                            ActionName="Bag"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="首饰",
                            Sorted=4,
                            ActionName="Accessories"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="其他",
                            Sorted=5,
                            ActionName="FashionOther"
                         },
                     }
                },
                new ChannelList(){
                     ChannelListName="文化生活",
                     Description="",
                     ControllerName=channels[0].ControllerName,
                     ActionName="CultureLife",
                     Sorted=4,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="乐器",
                            Sorted=1,
                            ActionName="MusicInstruments"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="印刷品",
                            Sorted=2,
                            ActionName="Books"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="玩具模型",
                            Sorted=3,
                            ActionName="Toys"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="文具",
                            Sorted=4,
                            ActionName="Stationary"
                         },
                          new ChannelListDetail(){
                            ChannelListDetailName="其他",
                            Sorted=5,
                            ActionName="CultureLifeOther"
                         }
                     }
                },
                new ChannelList(){
                     ChannelListName="其他",
                     Description="",
                     ControllerName=channels[0].ControllerName,
                     ActionName="Other",
                     Sorted=5,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="Other",
                            Sorted=1,
                            ActionName="OtherOther"
                         }
                     }
                }
            };
            goodsList.ForEach(r => r.TransferController = r.ControllerName + "Transfer");
            goodsList.ForEach(r => r.BuyController = r.ControllerName + "Buy");
            goodsList.ForEach(r => channels[0].ChannelLists.Add(r));
            #endregion

            #region 汽车交易
            var carList = new List<ChannelList>() { 
                new ChannelList(){
                     ChannelListName="二手汽车",
                     Description="",
                     ControllerName=channels[1].ControllerName,
                     ActionName="SecondHandCar",
                     Sorted=1,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="奥迪",
                            Sorted=1,
                            ActionName="Audi"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="宝马",
                            Sorted=2,
                            ActionName="BMW"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="别克",
                            Sorted=3,
                            ActionName="Buick"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="雪铁龙",
                            Sorted=4,
                            ActionName="Citroen"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="福特",
                            Sorted=5,
                            ActionName="Ford"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="本田",
                            Sorted=6,
                            ActionName="Honda"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="丰田",
                            Sorted=7,
                            ActionName="Toyota"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="日产",
                            Sorted=8,
                            ActionName="Nissan"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="MINI",
                            Sorted=9,
                            ActionName="MINI"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="奔驰",
                            Sorted=10,
                            ActionName="MercedesBenz"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="标致",
                            Sorted=11,
                            ActionName="Peugeot"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="大众",
                            Sorted=12,
                            ActionName="VW"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="沃尔沃",
                            Sorted=13,
                            ActionName="Volvo"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="其他品牌",
                            Sorted=14,
                            ActionName="SecondHandCarOther"
                         },
                     }
                },
                //new ChannelList(){
                //     ChannelListName="汽车配件",
                //     Description="",
                //     ControllerName=channels[1].ControllerName,
                //     ActionName="CarAccessories",
                //     Sorted=2,
                //     ChannelListDetails=new List<ChannelListDetail>(){
                //         new ChannelListDetail(){
                //            ChannelListDetailName="GPS",
                //            Sorted=1,
                //            ActionName="GPS"
                //         },
                //         new ChannelListDetail(){
                //            ChannelListDetailName="汽车装饰",
                //            Sorted=2,
                //            ActionName="Cardecoration"
                //         },
                //         new ChannelListDetail(){
                //            ChannelListDetailName="其他",
                //            Sorted=3,
                //            ActionName="Ohter"
                //         }
                //     }
                //}
            };
            carList.ForEach(r => r.TransferController = r.ControllerName + "Transfer");
            carList.ForEach(r => r.BuyController = r.ControllerName + "Buy");
            carList.ForEach(r => channels[1].ChannelLists.Add(r));
            #endregion

            #region 租房信息
            var houseList = new List<ChannelList>() { 
                new ChannelList(){
                     ChannelListName="商业用房",
                     Description="",
                     ControllerName=channels[2].ControllerName,
                     ActionName="CommercialProperties",
                     Sorted=1,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="展销商铺",
                            Sorted=1,
                            ActionName="Shop"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="饮食商铺",
                            Sorted=2,
                            ActionName="Restaurants"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="仓库",
                            Sorted=3,
                            ActionName="Warehouse"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="办公室",
                            Sorted=4,
                            ActionName="Office"
                         }
                     }
                },
                new ChannelList(){
                     ChannelListName="居住用房",
                     Description="",
                     ControllerName=channels[2].ControllerName,
                     ActionName="Properties",
                     Sorted=2,
                     ChannelListDetails=new List<ChannelListDetail>(){
                         new ChannelListDetail(){
                            ChannelListDetailName="House",
                            Sorted=1,
                            ActionName="House"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="Flat",
                            Sorted=2,
                            ActionName="Flat"
                         },
                         new ChannelListDetail(){
                            ChannelListDetailName="学生公寓",
                            Sorted=3,
                            ActionName="StudentAparment"
                         }
                     }
                }
            };
            houseList.ForEach(r => r.TransferController = r.ControllerName + "Transfer");
            houseList.ForEach(r => r.BuyController = r.ControllerName + "Buy");
            houseList.ForEach(r => channels[2].ChannelLists.Add(r));
            #endregion

            channels.ForEach(r => context.Channels.Add(r));
            #endregion

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {

                throw ex;
            }

            #region 二手物品新旧信息建立
            var goodsConditons = new List<GoodsCondition>() { 
                new GoodsCondition(){
                     GoodsConditionName="未开封，配件齐全，全新",
                     Description="未开封，配件齐全",
                     IsHasMessage=false,
                     PlaceHolder="",
                     Sorted=1
                },
                new GoodsCondition(){
                     GoodsConditionName="无磨损，配件齐全，功能齐全",
                     Description="无磨损，配件齐全",
                     IsHasMessage=false,
                     PlaceHolder="",
                     Sorted=2
                },
                new GoodsCondition(){
                     GoodsConditionName="有磨损或配件不齐全，功能齐全",
                     Description="有磨损或配件不齐全",
                     IsHasMessage=true,
                     PlaceHolder="请填写磨损或配件问题",
                     Sorted=3
                },
                new GoodsCondition(){
                     GoodsConditionName="配件齐全，部分功能不可用",
                     Description="配件齐全",
                     IsHasMessage=true,
                     PlaceHolder="请填写功能问题",
                     Sorted=4
                },
                new GoodsCondition(){
                     GoodsConditionName="配件不全，部分功能不可用",
                     Description="配件不全",
                     IsHasMessage=true,
                     PlaceHolder="请填写配件以及功能问题",
                     Sorted=5
                },
            };
            #endregion
            goodsConditons.ForEach(r => context.GoodsConditions.Add(r));
            context.SaveChanges();
        }
    }
}