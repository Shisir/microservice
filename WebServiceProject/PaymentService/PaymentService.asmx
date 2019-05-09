<%@ WebService Language="C#" Class="PaymentService.PaymentService" %>

using System;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;

namespace PaymentService
{
    [WebService(Namespace = "dse.webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
	class PaymentService: WebService
	{
        private IDbConnection dbcon;
        public PaymentService(){
            string connectionString =
                "Server=localhost;" +
                "Database=OEFSV;" +
                "User ID=root;" +
                "Password=root;" +
                "Pooling=false;"+
                "SslMode=none";
            dbcon = new MySqlConnection(connectionString);

        }
        
        [WebMethod]
        public int createPayment(String regNum){
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            
            string sql = "INSERT INTO bankPaymentFormFillup (regNum, transacNum) VALUES('" +regNum+ "', Floor(Rand()*1000000));";
            dbcmd.CommandText = sql;
            dbcmd.ExecuteNonQuery();
            
            sql = "SELECT transacNum FROM bankPaymentFormFillup where regNum ='"+ regNum+"' order by id DESC limit 1;";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            int transacNum = -1;
            if(reader.Read()){
                transacNum = (int) reader["transacNum"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return transacNum;
        }

        [WebMethod]
        public double getPayment(String transactionNum){
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            string sql = "SELECT amount FROM payment where transacNum ='"+transactionNum+"';";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            double amount = -1;
            if(reader.Read()){
                amount = (float) reader["amount"];
            }
            reader.Close();
            dbcmd.Dispose();
            dbcon.Close();
            return amount;
        }
	}
}
