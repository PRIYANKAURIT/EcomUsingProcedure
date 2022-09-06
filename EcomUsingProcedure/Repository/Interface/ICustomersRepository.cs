using EcomUsingProcedure.Model;

namespace EcomUsingProcedure.Repository.Interface
{
    public interface ICustomersRepository
    {
        public Task<IEnumerable<customers>> viewcustomers();
        //public Task<int> Registration(gender gen, DtoRegistration reg);
        public Task<customers> Login(DtoLogin log);
        public Task<int> IUDCustomer(gender gen, customers cust);
    }
}
