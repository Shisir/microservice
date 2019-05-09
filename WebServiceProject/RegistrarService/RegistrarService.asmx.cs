using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;

namespace RegistrarService
{
    [WebService(Namespace = "dse.webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class RegistrarService : System.Web.Services.WebService
    {
        private IDbConnection dbcon;
        public RegistrarService()
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
        public StudentRegistrarInfo GetStudentInfoFromRegistrar(string regNum)
        {
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            StudentRegistrarInfo student = null;

            string sql = "SELECT * FROM registrarInfo where regNum ='" + regNum + "';";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                student = new StudentRegistrarInfo();
                student.regNum = regNum;
                student.universityFee = (double)reader["universityFee"];
                student.examRoll = (int)reader["examRoll"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return student;
        }
        [WebMethod]
        public int CreateStudentRollFromRegistrar(string regNum)
        {
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();

            string sql = "UPDATE registrarInfo SET examRoll = Floor(Rand() * 10000) WHERE regNum = '" + regNum + "';";
            dbcmd.CommandText = sql;
            dbcmd.ExecuteNonQuery();

            sql = "SELECT examRoll FROM registrarInfo where regNum ='" + regNum + "' order by id DESC limit 1;";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            int examRoll = -1;
            if (reader.Read())
            {
                examRoll = (int)reader["examRoll"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return examRoll;
        }


    }
}
