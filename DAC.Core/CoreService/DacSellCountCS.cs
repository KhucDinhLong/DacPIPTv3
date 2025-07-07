using System;
using DAC.DAL;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAC.Core
{
    public class DacSellCountCS
    {
        public List<DacSellCount> GetListSellCount(string UnitCode, string PromotionCode, string ProductCode)
        {
            List<DacSellCount> dacProductCollection = new List<DacSellCount>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@UnitCode", UnitCode);
            dacDb.AddParameter("@PromotionCode", PromotionCode);
            dacDb.AddParameter("@ProductCode", ProductCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacSellCount_Select");

            while(reader.Read())
            {
                DacSellCount dacProduct = new DacSellCount();

                dacProduct.Id = (int)reader["Id"];
                dacProduct.UnitCode = reader["UnitCode"].ToString();
                dacProduct.SellDate = (DateTime)reader["SellDate"];
                dacProduct.TxtType = (bool)reader["TxtType"];
                dacProduct.PromotionCode = reader["PromotionCode"].ToString();
                dacProduct.ProductCode = reader["ProductCode"].ToString();
                dacProduct.Memo = reader["Memo"].ToString();
                dacProduct.Active = (bool)reader["Active"];

                // Cac phan chua su dung
                dacProduct.SellCount = reader["SellCount"] == DBNull.Value ? 0 : (int)reader["SellCount"];
                dacProduct.StartingNumber = reader["StartingNumber"] == DBNull.Value ? 0 : Convert.ToInt64(reader["StartingNumber"]);
                dacProduct.snyn = reader["snyn"] == DBNull.Value ? false : (bool)reader["snyn"];
                dacProduct.snbegin = reader["snbegin"].ToString();
                dacProduct.snend = reader["snend"].ToString();
                dacProduct.EndDate = reader["EndDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["EndDate"];

                dacProductCollection.Add(dacProduct);
            }

            //Call Close when reading done.
            reader.Close();

            return dacProductCollection;
        }

        /// <summary>
        /// Luu o PIPT Server
        /// </summary>
        /// <param name="dacSellCount"></param>
        /// <returns></returns>
        public bool Insert(DacSellCount dacSellCount)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                //dacDb.AddParameter("@ID", dacSellCount.ID);
                dacDb.AddParameter("@UnitCode", dacSellCount.UnitCode);
                dacDb.AddParameter("@SellCount", dacSellCount.SellCount);
                dacDb.AddParameter("@StartingNumber", dacSellCount.StartingNumber);
                dacDb.AddParameter("@SellDate", dacSellCount.SellDate);
                dacDb.AddParameter("@TxtType", dacSellCount.TxtType);
                dacDb.AddParameter("@PromotionCode", dacSellCount.PromotionCode);
                dacDb.AddParameter("@ProductCode", dacSellCount.ProductCode);
                dacDb.AddParameter("@Memo", dacSellCount.Memo);
                dacDb.AddParameter("@Active", dacSellCount.Active);

                dacDb.AddParameter("@snyn", dacSellCount.snyn);
                dacDb.AddParameter("@snbegin", dacSellCount.snbegin);
                dacDb.AddParameter("@snend", dacSellCount.snend);
                dacDb.AddParameter("@EndDate", dacSellCount.EndDate);

                dacDb.ExecuteNonQuery("spDacSellCount_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(DacSellCount dacSellCount)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", dacSellCount.Id);
                dacDb.AddParameter("@UnitCode", dacSellCount.UnitCode);
                dacDb.AddParameter("@SellCount", dacSellCount.SellCount);
                dacDb.AddParameter("@StartingNumber", dacSellCount.StartingNumber);
                dacDb.AddParameter("@SellDate", dacSellCount.SellDate);
                dacDb.AddParameter("@TxtType", dacSellCount.TxtType);
                dacDb.AddParameter("@PromotionCode", dacSellCount.PromotionCode);
                dacDb.AddParameter("@ProductCode", dacSellCount.ProductCode);
                dacDb.AddParameter("@Memo", dacSellCount.Memo);
                dacDb.AddParameter("@Active", dacSellCount.Active);

                dacDb.AddParameter("@snyn", dacSellCount.snyn);
                dacDb.AddParameter("@snbegin", dacSellCount.snbegin);
                dacDb.AddParameter("@snend", dacSellCount.snend);
                dacDb.AddParameter("@EndDate", dacSellCount.EndDate);

                dacDb.ExecuteNonQuery("spDacSellCount_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int ID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", ID);

                dacDb.ExecuteNonQuery("spDacSellCount_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
