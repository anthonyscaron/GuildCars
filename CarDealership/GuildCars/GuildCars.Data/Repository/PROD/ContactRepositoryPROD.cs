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
    public class ContactRepositoryPROD : IContactRepository
    {
        public void CreateContact(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);

                if (string.IsNullOrEmpty(contact.ContactEmail))
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                }

                if (string.IsNullOrEmpty(contact.ContactPhone))
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", contact.ContactPhone);
                }

                cmd.Parameters.AddWithValue("@Message", contact.Message);

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactId = (int)param.Value;
            }
        }

        public List<Contact> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Contact> contacts = new List<Contact>();
                SqlCommand cmd = new SqlCommand("ContactGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactId = (int)dr["ContactId"];
                        currentRow.ContactName = dr["ContactName"].ToString();
                        currentRow.ContactEmail = dr["ContactEmail"].ToString();
                        currentRow.ContactPhone = dr["ContactPhone"].ToString();

                        if (dr["Message"] != DBNull.Value)
                        {
                            currentRow.Message = dr["Message"].ToString();
                        }                    

                        contacts.Add(currentRow);
                    }
                }

                return contacts;
            }
        }
    }
}
