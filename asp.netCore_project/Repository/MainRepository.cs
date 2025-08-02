using asp.netCore_project.Data;
using asp.netCore_project.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace asp.netCore_project.Repository
{
    public class MainRepository<T> : IRepositry<T> where T : class
    {
        public MainRepository(AppDbContext context)
        {
            Context = context;
        }

        protected AppDbContext Context;

        public T FindById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = Context.Set<T>();
            if (agers != null && agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = Context.Set<T>();
            if (agers != null && agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            
            return await query.ToListAsync();
        }

        public void AddOne(T myItim)
        {
            Context.Set<T>().Add(myItim);
            Context.SaveChanges();
        }

        public void DeleteOne(T myItim)
        {
            Context.Set<T>().Remove(myItim);
            Context.SaveChanges();
        }

        public void UpdateOne(T myItim)
        {
            Context.Set<T>().Update(myItim);
            Context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            Context.Set<T>().AddRange(myList);
            Context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            Context.Set<T>().RemoveRange(myList);
            Context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            Context.Set<T>().UpdateRange(myList);
            Context.SaveChanges();
        }
    }
}
