using asp.netCore_project.Models;

namespace asp.netCore_project.Repository.Base
{
    public interface IUntiOfWork :IDisposable
    {
        IRepositry<Category> Categories{ get; }
        IRepositry<items> items { get; }

        IEmprepo Employees { get; }

        int commitChangies();
    }
}
