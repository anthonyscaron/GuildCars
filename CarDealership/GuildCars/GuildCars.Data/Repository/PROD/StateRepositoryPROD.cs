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
    public class StateRepositoryPROD : IStateRepository
    {
        public List<State> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<State> states = new List<State>();
                SqlCommand cmd = new SqlCommand("StateGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateId = (int)dr["StateId"];
                        currentRow.StateAbbreviation = dr["StateAbbreviation"].ToString();

                        states.Add(currentRow);
                    }
                }

                return states;
            }
        }
    }
}
