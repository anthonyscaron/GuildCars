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
    public class MakeRepositoryPROD : IMakeRepository
    {
        public void CreateMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@DateAdded", make.DateAdded);
                cmd.Parameters.AddWithValue("@AddedByUser", make.AddedByUser);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            }
        }

        public List<Make> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Make> makes = new List<Make>();
                SqlCommand cmd = new SqlCommand("MakeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.AddedByUser = dr["AddedByUser"].ToString();

                        makes.Add(currentRow);
                    }
                }

                return makes;
            }
        }
    }
}
