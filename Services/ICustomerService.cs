using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        HttpStatusCode Insert(UpsertCostumer costumer);
        [OperationContract]
        HttpStatusCode Update(UpsertCostumer costumer);
        [OperationContract]
        GetCostumer GetCustomer(int id);
        [OperationContract]
        IEnumerable<GetCostumer> GetAllCustomers();
        
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UpsertCostumer
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; } = string.Empty;
        [DataMember] public string Email { get; set; } = string.Empty;
        [DataMember] public string Phone { get; set; } = string.Empty;
    }

    [DataContract]
    public class GetCostumer
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; } = string.Empty;
        [DataMember] public string Email { get; set; } = string.Empty;
        [DataMember] public string Phone { get; set; } = string.Empty;
    }

    [DataContract]
    public class GetAllCostumers
    {
        [DataMember] public IEnumerable<GetCostumer> Customers { get; set; }
    }
}