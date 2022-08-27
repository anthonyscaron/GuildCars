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
    public class ColorExRepositoryPROD : IColorExRepository
    {
        public List<ColorEx> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<ColorEx> colorExs = new List<ColorEx>();
                SqlCommand cmd = new SqlCommand("ColorExGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ColorEx currentRow = new ColorEx();
                        currentRow.ColorExId = (int)dr["ColorExId"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();

                        colorExs.Add(currentRow);
                    }
                }

                return colorExs;
            }
        }
    }
}
