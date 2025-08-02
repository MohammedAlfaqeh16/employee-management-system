using asp.netCore_project.Data;
using asp.netCore_project.Models;
using asp.netCore_project.Repository.Base;

namespace asp.netCore_project.Repository
{
    public class UnitOfWork : IUntiOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
            Categories=new MainRepository<Category>(Context);
            items=new MainRepository<items>(Context);
            Employees = new Emprepo(Context);
        }

        private readonly AppDbContext Context;

        public IRepositry<Category> Categories { get; private set; }

        public IRepositry<items> items { get; private set; }

        public IEmprepo Employees { get; private set; }

        

        public int commitChangies()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
           Context.Dispose();
        }
    }
}
