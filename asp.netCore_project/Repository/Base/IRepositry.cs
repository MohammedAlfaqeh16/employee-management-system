using System.Linq.Expressions;

namespace asp.netCore_project.Repository.Base
{
    public interface IRepositry<T> where T : class 
    {

        T FindById(int id);
        T SelectOne(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(params string[] agers);
        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne(T myItim);
        void DeleteOne(T myItim);
        void UpdateOne(T myItim);
        void AddList(IEnumerable<T> myItim);
        void DeleteList(IEnumerable<T> myItim);
        void UpdateList(IEnumerable<T> myItim);
    }
    
}
