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
    public class SpecialRepositoryPROD : ISpecialRepository
    {
        public void CreateSpecial(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@Description", special.Description);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialId = (int)param.Value;
            }
        }
        public void DeleteSpecial(int specialId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<Special> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Special> specials = new List<Special>();
                SqlCommand cmd = new SqlCommand("SpecialGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        specials.Add(currentRow);
                    }
                }

                return specials;
            }
        }
        public Special GetSpecialById(int specialId)
        {
            Special special = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("SpecialGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special = new Special();
                        special.SpecialId = (int)dr["SpecialId"];
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.Description = dr["Description"].ToString();
                    }
                }
            }

            return special;
        }
    }
}
