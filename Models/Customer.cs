namespace CRUD_OData_Tutorial.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal CreditLimit { get; set; }
        public DateTime CustomerSince { get; set; }
    }

    public enum CustomerType
    {
        Retail,
        Wholesale
    }
}
