using LanguageCenter.BLL;
using LanguageCenter.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.BLL 
{
    class AccountDAO
    {
        public AccountDAO()
        {
        }
        public Account getAccountByUsername(string username, string password)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();

            command.CommandText = "select * from Accounts where Accounts.Username = @username";
            command.Parameters.Add(new SqlParameter("@username", username));
            Account account = new Account();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    account.Username = Convert.ToString(reader["Username"]);
                    account.Password = Convert.ToString(reader["Password"]);
                    account.RoleID = Convert.ToInt32(reader["RoleID"]);

                    return account;
                }
            }
            catch (Exception){}
            return account;
        }

        public int getRoleByUserName(string username)
        {
            int role;
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();

            command.CommandText = "select Accounts.RoleID from Accounts where Accounts.Username = @username";
            command.Parameters.Add(new SqlParameter("@username", username));

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (!reader.Read())
                {
                    return -1;
                }
                role = Convert.ToInt32(reader["RoleID"]);
                return role;
            }
        }

        public string getRoleName(string username)
        {
            string role_name;
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();

            command.CommandText = "select Staff.Position from Accounts inner join Staff on Accounts.Username=Staff.Username where Accounts.Username = @username";
            command.Parameters.Add(new SqlParameter("@username", username));

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (!reader.Read())
                {
                    return "";
                }
                role_name = Convert.ToString(reader["Position"]);
                return role_name;
            }
        }
    }
}
