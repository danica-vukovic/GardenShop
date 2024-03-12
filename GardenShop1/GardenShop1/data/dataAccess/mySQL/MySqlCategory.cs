using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.exceptions;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using GardenShop1.data.model;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics;

namespace GardenShop1.data.dataAccess.mySQL
{
    public class MySqlCategory: ICategory
    {
        private static readonly string SELECT = "SELECT * FROM `category`";
        private static readonly string SELECT_BY_ID = "SELECT * FROM `category` WHERE idCategory = @id";
        public List<Category> GetCategories()
        {

            List<Category> result = new List<Category>();
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
                    result.Add(new Category()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlCategory", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public string FindById(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            String result = "";
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_BY_ID;
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = reader.GetString(1);
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
    }
}
