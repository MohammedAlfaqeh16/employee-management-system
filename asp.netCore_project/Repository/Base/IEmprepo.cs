using asp.netCore_project.Models;

namespace asp.netCore_project.Repository.Base
{
    public interface IEmprepo :IRepositry<Employee>
    {
        void setPayRoll(Employee employee);

        decimal getPayRoll( Employee employee);
    }
}
