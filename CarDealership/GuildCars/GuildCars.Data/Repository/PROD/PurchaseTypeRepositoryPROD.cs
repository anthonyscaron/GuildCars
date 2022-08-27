using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.PROD
{
    public class PurchaseTypeRepositoryPROD : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<PurchaseType> purchaseTypes = new List<PurchaseType>();
                SqlCommand cmd = new SqlCommand("PurchaseTypeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.PurchaseTypeName = dr["PurchaseTypeName"].ToString();

                        purchaseTypes.Add(currentRow);
                    }
                }

                return purchaseTypes;
            }
        }
    }
}
