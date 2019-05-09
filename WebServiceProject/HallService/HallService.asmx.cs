using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;

namespace HallService
{
    [WebService(Namespace = "dse.webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class HallService : System.Web.Services.WebService
    {
        private IDbConnection dbcon;
        public HallService()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=OEFSV;" +
                "User ID=root;" +
                "Password=root;" +
                "Pooling=false;" +
                "SslMode=none";
            dbcon = new MySqlConnection(connectionString);

        }

        [WebMethod]
        public StudentHallInfo GetStudentInfoFromHall(string regNum)
        {
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            StudentHallInfo student = null;

            string sql = "SELECT * FROM hallInfo where regNum ='" + regNum + "';";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                student = new StudentHallInfo();
                student.regNum = regNum;
                student.is_resident = (bool)reader["is_resident"];
                student.hall_payment_res = (double)reader["hall_payment_res"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return student;
        }

    }
}
