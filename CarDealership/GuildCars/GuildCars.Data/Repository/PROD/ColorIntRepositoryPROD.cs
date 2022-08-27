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
    public class ColorIntRepositoryPROD : IColorIntRepository
    {
        public List<ColorInt> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<ColorInt> colorInts = new List<ColorInt>();
                SqlCommand cmd = new SqlCommand("ColorIntGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ColorInt currentRow = new ColorInt();
                        currentRow.ColorIntId = (int)dr["ColorIntId"];
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();

                        colorInts.Add(currentRow);
                    }
                }

                return colorInts;
            }
        }
    }
}
