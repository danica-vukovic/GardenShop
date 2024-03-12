using GardenShop1.data.exceptions;
using GardenShop1.data.model;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GardenShop1.data.dataAccess.mySQL
{
    public class MySqlArticle : IArticle
    {
        private static readonly string SELECT_BY_CODE = "SELECT * FROM `article` WHERE  idArticle = @a_code";
        private static readonly string SELECT = "SELECT * FROM `article` WHERE isAvailable=true";
        private static readonly string DELETE = "UPDATE `article` SET isAvailable=false WHERE idArticle = @a_code";
        private static readonly string UPDATE = "UPDATE `article` SET idArticle=@a_code, name=@a_name, picture=@a_picture, description=@a_description, availableQuantity=@a_availableQuantity, salePrice=@a_salePrice, procurementPrice = @a_procurementPrice, category_idCategory=@a_category WHERE idArticle=@previousCode";
        private static readonly string INSERT = "INSERT INTO `article`(idArticle, name, picture, description, availableQuantity, salePrice, procurementPrice, Category_idCategory, isAvailable) VALUES (@a_code, @a_name, @a_picture, @a_description, @a_availableQuantity, @a_salePrice, @a_procurementPrice, @a_category, @a_isAvailable)";
        private static readonly string UPDATE_QUANTITY = "UPDATE `article` SET availableQuantity=@quantity  WHERE idArticle=@code";
        public bool AddArticle(Article article) {

            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@a_code", article.Code);
                cmd.Parameters.AddWithValue("@a_name", article.Name );
                cmd.Parameters.AddWithValue("@a_picture",article.Picture );
                cmd.Parameters.AddWithValue("@a_description", article.Description );
                cmd.Parameters.AddWithValue("@a_availableQuantity", article.AvailableQuantity );
                cmd.Parameters.AddWithValue("@a_salePrice", article.SalePrice );
                cmd.Parameters.AddWithValue("@a_procurementPrice", article.ProcurementPrice);
                cmd.Parameters.AddWithValue("a_category", article.Category );
                cmd.Parameters.AddWithValue("a_isAvailable", article.isAvailable);
                result = cmd.ExecuteNonQuery() == 1;
                article.Code = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }
        public Article FindByCode(int code)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_BY_CODE;
                cmd.Parameters.AddWithValue("@a_code", code);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Article()
                    {
                        Code = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Picture = reader.GetString(2),
                        Description = reader.GetString(3),
                        AvailableQuantity = reader.GetInt32(4),
                        SalePrice = reader.GetDecimal(5),
                        ProcurementPrice = reader.GetDecimal(6),
                        Category = reader.GetInt32(7)
                    };
                }
              
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }

            return null;
        }

        public List<Article> GetArticles()
        {

            List<Article> result = new List<Article>();
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
                    result.Add(new Article()
                    {
                        Code = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Picture = reader.GetString(2),
                        Description = reader.GetString(3),
                        AvailableQuantity = reader.GetInt32(4),
                        SalePrice = reader.GetDecimal(5),
                        ProcurementPrice = reader.GetDecimal(6),
                        Category = reader.GetInt32(7)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
        public bool DeleteArticle(int code)
        {

            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@a_code", code);
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return result;
        }

        public bool UpdateArticle(Article article, string previousCode)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@a_code", article.Code);
                cmd.Parameters.AddWithValue("@a_name", article.Name);
                cmd.Parameters.AddWithValue("@a_picture", article.Picture);
                cmd.Parameters.AddWithValue("@a_description", article.Description);
                cmd.Parameters.AddWithValue("@a_availableQuantity", article.AvailableQuantity);
                cmd.Parameters.AddWithValue("@a_salePrice", article.SalePrice);
                cmd.Parameters.AddWithValue("@a_procurementPrice", article.ProcurementPrice);
                cmd.Parameters.AddWithValue("@a_category", article.Category);
                cmd.Parameters.AddWithValue("@previousCode", Convert.ToInt32(previousCode));
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public bool UpdateQuantity(int value, int code)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_QUANTITY;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@quantity", value);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in MySqlArticle", ex);
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
    }


}
