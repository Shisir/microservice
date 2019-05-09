using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;

namespace DepartmentService
{
    [WebService(Namespace = "dse.webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class DepartmentService : WebService
    {
        private IDbConnection dbcon;
        public DepartmentService()
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
        public StudentDeptInfo GetStudentInfoFromDept(string regNum)
        {
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            StudentDeptInfo student = null;

            string sql = "SELECT * FROM departmentInfo where regNum ='" + regNum + "';";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                student = new StudentDeptInfo();
                student.regNum = regNum;
                student.attendance = (double)reader["attendance"];
                student.dept_payment = (double)reader["dept_payment"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return student;
        }
    }
}
