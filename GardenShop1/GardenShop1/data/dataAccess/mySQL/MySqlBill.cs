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
    public class MySqlBill : IBill
    {
        private static readonly string INSERT = "INSERT INTO `bill`(totalPrice, date, User_idUser) VALUES (@b_totalPrice, @b_date, @b_idUser)";
        private static readonly string SELECT = "SELECT * FROM `bill`";
        private static readonly string SELECT_BY_USER_ID = "SELECT * FROM `bill` WHERE user_idUser=@idUser";

        public int AddBill(Bill bill)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@b_totalPrice", bill.TotalPrice);
                cmd.Parameters.AddWithValue("@b_date", bill.Date);
                cmd.Parameters.AddWithValue("@b_idUser", bill.IdUser);
                result = cmd.ExecuteNonQuery() == 1;
                bill.Id = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlBill", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return bill.Id;
        }

      
        public List<Bill> GetBills(int idUser)
        {

            List<Bill> result = new List<Bill>();
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
                    result.Add(new Bill()
                    {
                        Id = reader.GetInt32(0),
                        TotalPrice = reader.GetDecimal(1),
                        Date = reader.GetDateTime(2),
                        IdUser = reader.GetInt32(3)

                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlBill", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    }
}
