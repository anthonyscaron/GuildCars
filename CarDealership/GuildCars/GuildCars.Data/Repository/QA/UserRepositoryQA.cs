using GuildCars.Data.Interface;
using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class UserRepositoryQA : IUserRepository
    {
        public List<AdminUserRequestItem> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<AdminUserRequestItem> users = new List<AdminUserRequestItem>();
                SqlCommand cmd = new SqlCommand("UsersGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AdminUserRequestItem currentRow = new AdminUserRequestItem();
                        currentRow.UserId = dr["Id"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Role = dr["Name"].ToString();
                        currentRow.ConfirmPassword = null;

                        users.Add(currentRow);
                    }
                }

                return users;
            }
        }

        public AdminUserRequestItem GetById(string userId)
        {
            AdminUserRequestItem user = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<AdminUserRequestItem> vehicles = new List<AdminUserRequestItem>();
                SqlCommand cmd = new SqlCommand("UsersGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        user = new AdminUserRequestItem();
                        user.UserId = dr["Id"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.FirstName = dr["FirstName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.Role = dr["Name"].ToString();
                        user.ConfirmPassword = null;
                    }
                }
            }

            return user;
        }
    }
}
