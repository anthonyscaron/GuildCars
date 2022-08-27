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
    public class BodyStyleRepositoryPROD : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<BodyStyle> bodyStyles = new List<BodyStyle>();
                SqlCommand cmd = new SqlCommand("BodyStyleGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }

                return bodyStyles;
            }
        }
    }
}
