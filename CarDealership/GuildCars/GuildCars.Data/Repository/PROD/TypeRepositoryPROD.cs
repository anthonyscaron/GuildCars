using GuildCars.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.PROD
{
    public class TypeRepositoryPROD : ITypeRepository
    {
        public List<Models.Table.Type> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Models.Table.Type> types = new List<Models.Table.Type>();
                SqlCommand cmd = new SqlCommand("TypeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Models.Table.Type currentRow = new Models.Table.Type();
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.TypeName = dr["TypeName"].ToString();

                        types.Add(currentRow);
                    }
                }

                return types;
            }
        }
    }
}
