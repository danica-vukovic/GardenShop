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
    public class MySqlBillItem : IBillItem
    {
        private static readonly string SELECT = "SELECT * FROM `billItem` WHERE bill_idBill=@idBill";
        private static readonly string INSERT_BILL_ITEM = "INSERT INTO `billitem`(quantity, price, article_idArticle, bill_idBill) VALUES (@b_quantity, @b_price, @b_idArticle, @b_idBill)";
        public bool AddBillItem(BillItem billItem)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_BILL_ITEM;
                cmd.Parameters.AddWithValue("@b_quantity", billItem.Quantity);
                cmd.Parameters.AddWithValue("@b_price", billItem.Price);
                cmd.Parameters.AddWithValue("@b_idArticle", billItem.IdArticle);
                cmd.Parameters.AddWithValue("@b_idBill", billItem.IdBill);
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlBillItem", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }

        public List<BillItem> GetBillItems(int idBill)
        {

            List<BillItem> result = new List<BillItem>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@idBill", idBill);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new BillItem()
                    {
                        Quantity = reader.GetInt32(0),
                        Price = reader.GetDecimal(1),
                        IdArticle = reader.GetInt32(2),
                        IdBill = reader.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlBillItem", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    }
}
