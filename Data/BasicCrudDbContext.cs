namespace CRUD_OData_Tutorial.Data
{
    public class BasicCrudDbContext : DbContext
    {
        public BasicCrudDbContext(DbContextOptions<BasicCrudDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
