using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc; 

namespace HousingU
{
    public class ConexionBD
    {
        public OdbcConnection con { get; set; }

        public ConexionBD()
        {
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/HousingU");
            System.Configuration.ConnectionStringSettings conString = webConfig.ConnectionStrings.ConnectionStrings["BDHousingU"];
            con = new OdbcConnection(conString.ToString());
            con.Open();
        }
    }
}