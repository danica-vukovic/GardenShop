using GardenShop1.data.exceptions;
using GardenShop1.data.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess.mySQL
{
    public class MySqlUser : IUser
    {
        private static readonly string UPDATE = "UPDATE `user` SET isAdmin=@u_isAdmin, name=@u_name, surname=@u_surname, username=@u_username, password=@u_password, phoneNumber=@u_phoneNumber, language=@u_language, theme=@u_theme  WHERE idUser=@u_idUser";
        private static readonly string INSERT = "INSERT INTO `user`(isAdmin, name, surname, username, password, phoneNumber, active, language,theme) VALUES (@u_isAdmin, @u_name, @u_surname, @u_username, @u_password, @u_phoneNumber, @u_active, @u_language, @u_theme)";
        private static readonly string SELECT = "SELECT * FROM `user` WHERE Active=true && isAdmin=false ORDER BY Name";
        private static readonly string SELECT_BY_USERNAME = "SELECT * FROM `user` WHERE  Username = @u_username";
        private static readonly string DELETE = "UPDATE `user`  SET Active=@u_active WHERE Username = @u_username";
        private static readonly string SELECT_BY_ID = "SELECT * FROM `user` WHERE  idUser = @idUser";

        public bool AddUser(User user)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@u_isAdmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@u_name", user.Name);
                cmd.Parameters.AddWithValue("@u_surname", user.Surname);
                cmd.Parameters.AddWithValue("@u_username", user.Username);
                cmd.Parameters.AddWithValue("@u_password", user.Password);
                cmd.Parameters.AddWithValue("@u_phoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@u_active", user.Active);
                cmd.Parameters.AddWithValue("@u_language", 1);
                cmd.Parameters.AddWithValue("@u_theme", 1);
                result = cmd.ExecuteNonQuery() == 1;
                user.Id = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }

        public bool UpdateUser(User user)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@u_idUser", user.Id);
                cmd.Parameters.AddWithValue("@u_isAdmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@u_name", user.Name);
                cmd.Parameters.AddWithValue("@u_surname", user.Surname);
                cmd.Parameters.AddWithValue("@u_username", user.Username);
                cmd.Parameters.AddWithValue("@u_password", user.Password);
                cmd.Parameters.AddWithValue("@u_phoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@u_language", user.Language);
                cmd.Parameters.AddWithValue("@u_theme", user.Theme);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public List<User> GetUsers()
        {

            List<User> result = new List<User>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Username = reader.GetString(3),
                        Password = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        IsAdmin = reader.GetBoolean(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public bool FindByUsername(String username)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_BY_USERNAME;
                cmd.Parameters.AddWithValue("@u_username", username);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }

            return false;
        }
        public  bool DeleteUser(String username){

            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@u_active", false);
                cmd.Parameters.AddWithValue("@u_username", username);
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }

        public User FindById(int idUser)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_BY_ID;
                cmd.Parameters.AddWithValue("@idUser", idUser);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User() { 
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Username = reader.GetString(3),
                        Password = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        IsAdmin = reader.GetBoolean(6),
                        Active = reader.GetBoolean(7)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlUser", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }

            return null;
        }

    }
}
