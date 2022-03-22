using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using Services.Customer.Interfaces;
using Services.Queries;

namespace Services.Customer.Implementation
{
     public class CustomerService : ICustomerService
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionStringSection].ConnectionString;
        /// <summary>
        /// Inserts customer data to the Database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>HttpStatusCode</returns>
        public HttpStatusCode InsertCustomer(UpsertCustomer customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(CustomerQueries.InsertCustomer, connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Phone", customer.Phone);
            var rowsEffected = command.ExecuteNonQuery();
            DisposeObjects(connection, command);
            if (rowsEffected > 0) return HttpStatusCode.OK;
            return HttpStatusCode.InternalServerError;
        }
        /// <summary>
        /// Updates the customer data in the Database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public HttpStatusCode UpdateCustomer(UpsertCustomer customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(CustomerQueries.UpdateCustomer, connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Phone", customer.Phone);
            command.Parameters.AddWithValue("@Id", customer.Id);
            var rowsEffected = command.ExecuteNonQuery();
            DisposeObjects(connection, command);
            if (rowsEffected > 0) return HttpStatusCode.OK;
            return HttpStatusCode.InternalServerError;
        }
        /// <summary>
        /// Returns customer matched with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GetCustomer</returns>
        public GetCustomer GetCustomer(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(CustomerQueries.GetCustomer, connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();
            GetCustomer customer;

            if (reader.Read())
                customer = new GetCustomer
                {
                    Id = (int) reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
            else
                return null;

            reader.Close();
            DisposeObjects(connection, command);
            return customer;
        }
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns>GetCustomers</returns>
        public GetCustomers GetAllCustomers()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(CustomerQueries.GetAllCustomers, connection);
            DataTable customerTable = new DataTable("Customer");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(customerTable);
            dataAdapter.Dispose();
            DisposeObjects(connection, command);
            return new GetCustomers() {Customers = customerTable};
        }
        /// <summary>
        /// Returns customers matching the name field with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>GetCustomers</returns>
        public GetCustomers SearchCustomer(string name)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(CustomerQueries.SearchCustomers, connection);
            command.Parameters.AddWithValue("@Name", name);
            DataTable customerTable = new DataTable("Customer");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(customerTable);
            dataAdapter.Dispose();
            DisposeObjects(connection, command);
            return new GetCustomers() { Customers = customerTable };
        }

        /// <summary>
        /// Dispose the command and connection objects
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <returns>void</returns>
        private void DisposeObjects(SqlConnection connection, SqlCommand command)
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}