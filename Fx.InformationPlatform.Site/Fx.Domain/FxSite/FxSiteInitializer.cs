using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite
{
    public class FxSiteInitializer : CreateDatabaseIfNotExists<FxSiteContext>
    {
        protected override void Seed(FxSiteContext context)
        {
            base.Seed(context);

            #region 地区城市初始化 邮编!!
            var areas = new List<Area>() { 
                new Area(){
                    AreaName="East Midlands",
                    Sorted=1,
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                         CityName="Southampton",
                         Sorted=13
                       },
                       new City(){
                         CityName="Winchester",
                         Sorted=14
                       },
                    }
                },
                new Area(){
                    AreaName="South West England",
                    Sorted=7,
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
                       new City(){
                         CityName="Birmingham",
                         Sorted=1
                       },
                       new City(){
                         CityName="Coventry",
                         Sorted=2
                       },
                       new City(){
                         CityName="Newport",
                         Sorted=3
                       },
                       new City(){
                         CityName="Keele",
                         Sorted=4
                       },
                       new City(){
                         CityName="Stoke on Trent",
                         Sorted=5
                       },
                       new City(){
                         CityName="Wolverhampton",
                         Sorted=6
                       },
                       new City(){
                         CityName="Worcester",
                         Sorted=7
                       }
                    }
                },
                 new Area(){
                    AreaName="Yorkshire and the Humber",
                    Sorted=9,
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
                    Citys=new List<City>(){
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
            context.SaveChanges();
        }
    }
}
