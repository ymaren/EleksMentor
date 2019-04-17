using Core.Dal.Ado.Net;
using Entity;
using ProductStore.Infustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //var connStr = WebConfigurationManager.ConnectionStrings["DefaultAdoNet"].ConnectionString;
            //string connectionString = "Data Source=DESKTOP-EN8J2M6\\SQLEXPRESS; Initial Catalog=LotShop; Persist Security Info=true; User ID=sa; Password=1";
           // var builder = new ObjectFactoryBuilder(); // 
            //AdoRepositoryFactory adorep = new AdoRepositoryFactory(connectionString);
            //var serv = adorep.CreateRepository<IProductView, int>();
            //var res = serv.GetAll();
            //builder.AddSource(new AdoRepositoryFactory(connectionString));
            //var factory = builder.Build();
            //ILotViewer service = factory.Create<ILotViewer>();
            //var results = service.ViewAll();
        }
    }
}
