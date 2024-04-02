using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StaticLibrary.WebUI.Models;
using StaticLibrary.WebUI.Services.Repository.Database;
using System.Reflection;

namespace StaticLibrary.WebUI.Services.Repository
{
    public class BaseRepo<T> : IRepository<T> where T : FullAuditModel
    {
        protected readonly DbContext? DbContext;
        public BaseRepo()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); // get all asseblies in solution
            IEnumerable<Type> allTypes = assemblies.SelectMany( x => x.GetTypes()); // all class type

            Type? dbContextType = allTypes.FirstOrDefault(x =>
                        typeof(DbContext).IsAssignableFrom(x)  &&
                        //x.GetProperties().Any(x => x.PropertyType == typeof(T)) &&
                        !x.IsAbstract);

            if (dbContextType is null) return;

            object? instance = Activator.CreateInstance(dbContextType);

            if(instance is DbContext dbContext)
            {
                DbContext = dbContext;
            }
        }

        public async Task<T?> Add(T entity)
        {
            if (DbContext is null) return null;

            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> Delete(int id)
        {
            if (DbContext is null) return null;

            T? entity = await GetById(id);

            if (entity is null) return null;

            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            if (DbContext is null) return null;

            return await DbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            if (DbContext is null) return null;

            return await DbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> Update(T entity)
        {
            if (DbContext is null) return null;

            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }
    }
}
