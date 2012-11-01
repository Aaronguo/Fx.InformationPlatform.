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
        static List<Lazy<DbConnection>> lazyList = new List<Lazy<DbConnection>>();

        static Connection()
        {
            Lazy<DbConnection> car = new Lazy<DbConnection>(() => new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.car-mysql"].ToString()));
            Lazy<DbConnection> goods = new Lazy<DbConnection>(() => new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.goods-mysql"].ToString()));
            Lazy<DbConnection> house = new Lazy<DbConnection>(() => new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["fx.house-mysql"].ToString()));
            Lazy<DbConnection> site = new Lazy<DbConnection>(() => new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["fx.site-sqlserver"].ToString()));
            lazyList.Add(car);
            lazyList.Add(house);
            lazyList.Add(goods);
            lazyList.Add(site);
        }
        public static DbConnection CreateConnection(FxConnection dbCatalog)
        {
             int index = (int)dbCatalog;
             Lazy<DbConnection> connection = lazyList[index];
             return connection.Value; ;
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
