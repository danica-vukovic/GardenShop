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
    public class MySqlProcurementItem : IProcurementItem
    {
        private static readonly string SELECT = "SELECT * FROM `procurementItem` WHERE procurement_idProcurement=@idProcurement";
        private static readonly string INSERT_PROCUREMENT_ITEM = "INSERT INTO `procurementitem`(quantity, price, article_idArticle, procurement_idProcurement) VALUES (@b_quantity, @b_price, @b_idArticle, @b_idProcurement)";
        public bool AddProcurementItem(ProcurementItem procurementItem)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_PROCUREMENT_ITEM;
                cmd.Parameters.AddWithValue("@b_quantity", procurementItem.Quantity);
                cmd.Parameters.AddWithValue("@b_price", procurementItem.Price);
                cmd.Parameters.AddWithValue("@b_idArticle", procurementItem.IdArticle);
                cmd.Parameters.AddWithValue("@b_idProcurement", procurementItem.IdProcurement);
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlProcurementItem", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }

        public List<ProcurementItem> GetProcurementItems(int idProcurement)
        {

            List<ProcurementItem> result = new List<ProcurementItem>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@idProcurement", idProcurement);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ProcurementItem()
                    {
                        Quantity = reader.GetInt32(0),
                        Price = reader.GetDecimal(1),
                        IdArticle = reader.GetInt32(2),
                        IdProcurement = reader.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlProcurementItem", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    }
}
