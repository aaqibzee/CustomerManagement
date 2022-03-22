using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public HttpStatusCode Insert(UpsertCostumer costumer)
        {
            var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var command = new SqlCommand(CostumerQueries.InsertCustomer, connection);
            command.Parameters.AddWithValue("@Name", costumer.Name);
            command.Parameters.AddWithValue("@Email", costumer.Email);
            command.Parameters.AddWithValue("@Phone", costumer.Phone);
            var rowsEffected = command.ExecuteNonQuery();
            DisposeObjects(connection, command);
            if (rowsEffected > 0) return HttpStatusCode.OK;
            return HttpStatusCode.InternalServerError;
        }

        public HttpStatusCode Update(UpsertCostumer costumer)
        {
            var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var command = new SqlCommand(CostumerQueries.UpdateCustomer, connection);
            command.Parameters.AddWithValue("@Name", costumer.Name);
            command.Parameters.AddWithValue("@Email", costumer.Email);
            command.Parameters.AddWithValue("@Phone", costumer.Phone);
            command.Parameters.AddWithValue("@Id", costumer.Id);
            var rowsEffected = command.ExecuteNonQuery();
            DisposeObjects(connection, command);
            if (rowsEffected > 0) return HttpStatusCode.OK;
            return HttpStatusCode.InternalServerError;
        }

        public GetCostumer GetCustomer(int id)
        {
            var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var command = new SqlCommand(CostumerQueries.GetCustomer, connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();
            GetCostumer costumer;

            if (reader.Read())
                costumer = new GetCostumer
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
            else
                return null;

            reader.Close();
            DisposeObjects(connection, command);
            return costumer;
        }

        public IEnumerable<GetCostumer> GetAllCustomers()
        {
            var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var command = new SqlCommand(CostumerQueries.GetAllCustomers, connection);
            var reader = command.ExecuteReader();
            var costumer = new GetCostumer();
            var costumersList = new List<GetCostumer>();

            if (reader.HasRows)
                while (reader.Read())
                {
                    costumer.Id = (int)reader["Id"];
                    costumer.Name = reader["Name"].ToString();
                    costumer.Email = reader["Email"].ToString();
                    costumer.Phone = reader["Phone"].ToString();
                    costumersList.Add(costumer);
                }

            else
                return null;

            reader.Close();
            DisposeObjects(connection, command);
            return costumersList;
        }

        private void DisposeObjects(SqlConnection connection, SqlCommand command)
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}