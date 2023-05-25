namespace CRUD_OData_Tutorial.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly BasicCrudDbContext _db;
        public CustomersController(BasicCrudDbContext db) => _db = db;

        /**
         * [GET]
         * Get all customers
        */
        public ActionResult<IQueryable<Customer>> Get()
        {
            return Ok(_db.Customers);
        }

        /**
         * [GET]
         * Get customer by Id
        */
        [HttpGet("odata/Customers({id})")]
        public ActionResult Get([FromRoute] int id)
        {
            var customer = _db.Customers.SingleOrDefault(d => d.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /**
         * [POST]
         * Create a customer
        */
        public ActionResult Post([FromBody] Customer customer)
        {
            _db.Customers.Add(customer);

            return Created(customer);
        }

        /**
         * [PUT]
         * Update all customer info
        */
        public ActionResult Put([FromRoute] int key, [FromBody] Customer updatedCustomer)
        {
            var customer = _db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.CustomerType = updatedCustomer.CustomerType;
            customer.CreditLimit = updatedCustomer.CreditLimit;
            customer.CustomerSince = updatedCustomer.CustomerSince;

            _db.SaveChanges();

            return Updated(customer);
        }

        /**
         * [PATCH]
         * Update a partial customer info
        */
        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Customer> delta)
        {
            var customer = _db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            _db.SaveChanges();

            return Updated(customer);
        }

        /**
         * [DELETE]
         * Delete a customer by Id
        */
        public ActionResult Delete([FromRoute] int key)
        {
            var customer = _db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
            }

            _db.SaveChanges();

            return NoContent();
        }
    }
}
