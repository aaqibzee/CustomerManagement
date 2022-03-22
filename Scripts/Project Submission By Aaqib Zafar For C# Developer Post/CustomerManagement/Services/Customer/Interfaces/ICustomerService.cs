using System.Data;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Services.Customer.Interfaces
{
    [ServiceContract]
    public interface ICustomerService
    {
        /// <summary>
        /// Inserts customer data 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [OperationContract]
        HttpStatusCode InsertCustomer(UpsertCustomer customer);

        /// <summary>
        /// Updates customer data
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [OperationContract]
        HttpStatusCode UpdateCustomer(UpsertCustomer customer);

        /// <summary>
        /// Returns customer matched with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        GetCustomer GetCustomer(int id);

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetCustomers GetAllCustomers();

        /// <summary>
        /// Returns customers matching the name field with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        GetCustomers SearchCustomer(string name);
    }

    [DataContract]
    public class UpsertCustomer : Customer
    {
    }

    [DataContract]
    public class GetCustomer : Customer
    {
    }

    [DataContract]
    public class GetCustomers
    {
        [DataMember] public DataTable Customers { get; set; }
    }

    [DataContract]
    public class SearchCustomers
    {
        [DataMember] public DataTable Customers { get; set; }
    }

    [DataContract]
    public class Customer
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; } = string.Empty;
        [DataMember] public string Email { get; set; } = string.Empty;
        [DataMember] public string Phone { get; set; } = string.Empty;
    }
}