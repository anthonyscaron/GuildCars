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
    public class ModelRepositoryPROD : IModelRepository
    {
        public void CreateModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@DateAdded", model.DateAdded);
                cmd.Parameters.AddWithValue("@AddedByUser", model.AddedByUser);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }

        public List<Model> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Model> models = new List<Model>();
                SqlCommand cmd = new SqlCommand("ModelGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.AddedByUser = dr["AddedByUser"].ToString();

                        models.Add(currentRow);
                    }
                }

                return models;
            }
        }

        public List<Model> GetByMakeName(string makeName)
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelGetByMakeName", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeName", makeName);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.AddedByUser = dr["AddedByUser"].ToString();

                        models.Add(currentRow);
                    }
                }   
            }

            return models;
        }
    }
}
