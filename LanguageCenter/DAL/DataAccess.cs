using LanguageCenter.GUI.mainForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.DAL
{
    class DataAccess
    {
        private static SqlConnection conn = null;

        public static SqlConnection getConnection()
        {
            if (conn == null)
            {
                try
                {
                    string userName = Login.username;
                    string passWord = Login.password;
                    string connectionString = string.Format(@"Data Source=.;Initial Catalog=LanguageCenter;User ID={0};Password={1}", userName, passWord);
                    conn = new SqlConnection(connectionString);
                    conn.Open();

                }
                catch (Exception){}  
            }
            return conn;
        }
    }
}
