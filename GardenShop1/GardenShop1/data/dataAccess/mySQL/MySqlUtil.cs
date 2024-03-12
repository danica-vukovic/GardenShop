using GardenShop1.data.exceptions;
using GardenShop1.data.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess.mySQL
{
    public static class MySqlUtil
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["GardenShop"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void CloseQuietly(MySqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch { }
        }

        public static void CloseQuietly(MySqlDataReader reader)
        {
            try
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            catch { }
        }

        public static void CloseQuietly(MySqlDataReader reader, MySqlConnection conn)
        {
            CloseQuietly(reader);
            CloseQuietly(conn);
        }

        public static User SignIn(string username, string password)
        {
            bool signIn = false;
            MySqlConnection connection = null;
            MySqlCommand cmd;

            try
            {

                connection = MySqlUtil.GetConnection();
                Console.WriteLine(connection.State);
                cmd = new MySqlCommand("signIn", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@u_username", MySqlDbType.String).Value = username;
                cmd.Parameters.Add("@u_password", MySqlDbType.String).Value = password;
                cmd.Parameters.Add("@u_signIn", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_idUser", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_name", MySqlDbType.String).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_surname", MySqlDbType.String).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_phoneNumber", MySqlDbType.String).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_isAdmin", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_language", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_theme", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@u_active", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@u_signIn"].Value != DBNull.Value)
                    signIn = Convert.ToBoolean(cmd.Parameters["@u_signIn"].Value);
                if (signIn)
                {              
                    User user = new User()
                    {
                        Id = Convert.ToInt32(cmd.Parameters["@u_idUser"].Value),
                        Name = Convert.ToString(cmd.Parameters["@u_name"].Value),
                        Surname = Convert.ToString(cmd.Parameters["@u_surname"].Value),
                        Username = username,
                        Password = password,
                        PhoneNumber = Convert.ToString(cmd.Parameters["@u_phoneNumber"].Value),
                        IsAdmin = Convert.ToBoolean(cmd.Parameters["@u_isAdmin"].Value),
                        Language = Convert.ToInt32(cmd.Parameters["@u_language"].Value),
                        Theme = Convert.ToInt32(cmd.Parameters["@u_theme"].Value),
                        Active = Convert.ToBoolean(cmd.Parameters["@u_active"].Value)
                    };
                    return user;
                }
                else {
                    return new User();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySQLUtil", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(connection);
            }
        }
    }
}
