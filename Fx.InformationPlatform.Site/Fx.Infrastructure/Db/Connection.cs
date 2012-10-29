using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Fx.Infrastructure.Db
{
    public class Connection
    {
        static Dictionary<int, DbConnection> dbCatalogs = new Dictionary<int, DbConnection>();

        static Connection()
        {
            DbConnection car = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.car-mysql"].ToString());
            DbConnection goods = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.goods-mysql"].ToString());
            DbConnection house = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.house-mysql"].ToString());
           
            DbConnection site = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["fx.site-sqlserver"].ToString());
            dbCatalogs[(int)FxConnection.FxCar] = car;
            dbCatalogs[(int)FxConnection.FxHouse] = house;
            dbCatalogs[(int)FxConnection.FxGoods] = goods;
            dbCatalogs[(int)FxConnection.FxSite] = site;

        }
        public static DbConnection CreateConnection(FxConnection dbCatalog)
        {
            int index = (int)dbCatalog;
            return dbCatalogs[index];
        }
    }


    public enum FxConnection
    {
        FxCar = 0,
        FxHouse = 1,
        FxGoods = 2,
        FxSite = 3
    }
}
