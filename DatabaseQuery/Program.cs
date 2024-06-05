using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseQuery {
  internal class Program {
    static void Main(string[] args) {

      SqlConnection conn = new SqlConnection("Server=DESKTOP-P1DVE48\\SQLEXPRESS;Database=GW2TradingPost;Trusted_Connection=True;");
      using (conn) {
        conn.Open();
        SqlCommand sqlCommand = new SqlCommand("EXEC TestProc @number, @text;",conn);
        sqlCommand.Parameters.Add("@number", System.Data.SqlDbType.Int);
        sqlCommand.Parameters["@number"].Value = 2;
        sqlCommand.Parameters.Add("@text", System.Data.SqlDbType.NVarChar, 100);
        sqlCommand.Parameters["@text"].Value = "Hello there!";

        using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
          while(reader.Read()) {
            Console.WriteLine($"{reader[0].ToString()}, {reader[1].ToString()}, {reader[2].ToString()}");
          }
        }
      }
      Console.WriteLine("Press enter to continue: ");
      Console.ReadLine();

    }
  }
}
