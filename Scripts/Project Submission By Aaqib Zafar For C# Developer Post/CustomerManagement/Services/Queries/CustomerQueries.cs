namespace Services.Queries
{
    public class CustomerQueries
    {
        public static readonly string GetCustomer = "SELECT * FROM [dbo].[Customer] WHERE Id = @Id";
        public static readonly string GetAllCustomers = "SELECT * FROM [dbo].[Customer]";
        public static readonly string SearchCustomers = "SELECT * FROM [CustomerManagementDB].[dbo].[Customer] WHERE Name LIKE @Name+'%'";
        public static readonly string InsertCustomer = "INSERT INTO [dbo].[Customer] (Name, Email,Phone) VALUES (@Name, @Email,@Phone)";
        public static readonly string UpdateCustomer = "UPDATE [dbo].[Customer] SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id=@Id";

    }
}