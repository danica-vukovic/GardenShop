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
    public class MySqlProcurement : IProcurement
    {
        private static readonly string INSERT = "INSERT INTO `procurement`(totalPrice, date, User_idUser, procurer_idProcurer) VALUES (@p_totalPrice, @p_date, @p_idUser, @p_idProcurer)";
        private static readonly string SELECT = "SELECT * FROM `procurement`";
        private static readonly string SELECT_BY_USER_ID = "SELECT * FROM `procurement` WHERE user_idUser=@idUser";

        public int AddProcurement(Procurement procurement)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@p_totalPrice", procurement.TotalPrice);
                cmd.Parameters.AddWithValue("@p_date", procurement.Date);
                cmd.Parameters.AddWithValue("@p_idUser", procurement.IdUser);
                cmd.Parameters.AddWithValue("@p_idProcurer", procurement.IdProcurer);
                result = cmd.ExecuteNonQuery() == 1;
                procurement.Id = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlProcurement", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return procurement.Id;
        }


        public List<Procurement> GetProcurements(int idUser)
        {

            List<Procurement> result = new List<Procurement>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                if (idUser > 0)
                {
                    cmd.CommandText = SELECT_BY_USER_ID;
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                }
                else
                {
                    cmd.CommandText = SELECT;
                }

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Procurement()
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        TotalPrice = reader.GetDecimal(2),
                        IdUser = reader.GetInt32(3),
                        IdProcurer = reader.GetInt32(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlProcurement", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    }
}

