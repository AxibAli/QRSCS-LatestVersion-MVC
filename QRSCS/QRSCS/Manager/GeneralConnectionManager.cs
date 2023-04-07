using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QRSCS.Manager
{
    public class GeneralConnectionManager
    {
        //MUHAMMAD AZIB ALI STRING
        //public static string conString = @"Data Source=DESKTOP-QAPTT3S; Initial Catalog=QRSCS_Database; Integrated Security=True";

        //ALI SHER STRING 
        public static string conString = @"Data Source=DESKTOP-C07D27O; Initial Catalog=New_QRSCS_Database; Integrated Security=True";

        public static SqlConnection con = new SqlConnection(conString);
    }

}