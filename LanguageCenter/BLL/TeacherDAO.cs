using LanguageCenter.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCenter.BLL
{
    class TeacherDAO
    {
        public TeacherDAO()
        {

        }
        public Teacher getTeacherByUsername(string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();

            command.CommandText = "select Username, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Name, Email, Phone from Teachers" +
                " where Teachers.Username = @username";
            command.Parameters.Add(new SqlParameter("@username", username));

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (!reader.Read())
                {
                    return null;
                }
                Teacher teacher = new Teacher();
                teacher.Username = Convert.ToString(reader["Username"]);
                teacher.Date_Birth = Convert.ToString(reader["DateOfBirth"]);
                teacher.Address = Convert.ToString(reader["Address"]);
                teacher.Name = Convert.ToString(reader["Name"]);
                teacher.Email = Convert.ToString(reader["Email"]);
                teacher.Phone = Convert.ToString(reader["Phone"]);

                return teacher;

            }
;
        }
    }
}
