using d3_avaliacao.Interface;
using d3_avaliacao.Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace d3_avaliacao.Controller
{
    internal class UserController : IUser
    {
        
        private readonly string stringConexao = "Server=DESKTOP-E4ANAGJ; Initial Catalog=base; User id=teste; pwd=123;";
        string encrypt(string pass)
        {
            byte[] b = Encoding.UTF8.GetBytes(pass);
            var crypt = new SHA256Managed();
            byte[] hash = crypt.ComputeHash(b);
            string res = string.Empty;
            foreach (byte theByte in hash)
            {
                res += theByte.ToString("x2");
            }
            return res;
        }
        public User Read(string email, string password)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT Salt FROM Users WHERE Email = @Email";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    password += rdr[0].ToString();
                    password = encrypt(password);
                    rdr.Close();
                }
                querySelect = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    user.Email = rdr["Email"].ToString();
                    user.Name = rdr[1].ToString();
                    user.Password = rdr[2].ToString();
                    user.Id = rdr[3].ToString();
                    rdr.Close();
                }
                con.Close();

            }
            return user;

        }
        
    }
}
