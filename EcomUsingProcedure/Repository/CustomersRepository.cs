using Dapper;
using EcomUsingProcedure.Context;
using EcomUsingProcedure.Model;
using EcomUsingProcedure.Repository.Interface;

namespace EcomUsingProcedure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> IUDCustomer(gender gen, customers cust)
        {
            var query = "sp_customer";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, cust, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<customers> Login(DtoLogin log)
        {
            var query = "searchcustmers";
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@cust_email", log.cust_email);
                var customer = await connection.QueryFirstOrDefaultAsync<customers>(query,dp,commandType:System.Data.CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<IEnumerable<customers>> viewcustomers()
        {
            var query = "selectcustomers";
            using (var connection = _context.CreateConnection())
            {
                var customer = await connection.QueryAsync<customers>(query);
                return customer.ToList();
            }
        }
    }
}
