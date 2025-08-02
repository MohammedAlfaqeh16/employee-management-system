using asp.netCore_project.Data;
using asp.netCore_project.Models;
using asp.netCore_project.Repository.Base;

namespace asp.netCore_project.Repository
{
    public class Emprepo : MainRepository<Employee>, IEmprepo
    {
        public Emprepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        private readonly AppDbContext Context;

        public decimal getPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
