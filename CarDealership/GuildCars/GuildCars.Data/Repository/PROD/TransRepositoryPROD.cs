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
    public class TransRepositoryPROD : ITransRepository
    {
        public List<Trans> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Trans> trans = new List<Trans>();
                SqlCommand cmd = new SqlCommand("TransGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Trans currentRow = new Trans();
                        currentRow.TransId = (int)dr["TransId"];
                        currentRow.TransName = dr["TransName"].ToString();

                        trans.Add(currentRow);
                    }
                }

                return trans;
            }
        }
    }
}
