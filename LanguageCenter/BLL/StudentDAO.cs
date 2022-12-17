using LanguageCenter.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCenter.BLL
{
    class StudentDAO
    {
        public StudentDAO()
        {

        }
        public Student getStudentByUsername(string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();

            command.CommandText = "select Username, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Name, Email, Phone from Students" +
                " where Students.Username = @username";
            command.Parameters.Add(new SqlParameter("@username", username));

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if(!reader.Read())
                {
                    return null;
                }
                Student st = new Student();

                st.Username = Convert.ToString(reader["Username"]);
                st.Date_Birth = Convert.ToString(reader["DateOfBirth"]);
                st.Address = Convert.ToString(reader["Address"]);
                st.Name = Convert.ToString(reader["Name"]);
                st.Email = Convert.ToString(reader["Email"]);
                st.Phone = Convert.ToString(reader["Phone"]);

                return st;
               
            }
;        }
    }
}
