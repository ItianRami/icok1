using icok1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icok1.Persistence
{
    public interface ICosmosDbServiceT<T>
    {
        Task<IEnumerable<T>> ListAsync(string query);
        Task<T> GetAsync(string id);
        Task AddAsync(T item);
        Task UpdateAsync(string id, T item);
        Task DeleteAsync(string id);
    }

    //public interface IProductCosmosDbService
    //{
    //    Task<IEnumerable<Product>> ListAsync(string query);
    //    Task<Product> GetAsync(string id);
    //    Task AddAsync(Product item);
    //    Task UpdateAsync(string id, Product item);
    //    Task DeleteAsync(string id);
    //}

    //public interface IOrderCosmosDbService
    //{
    //    Task<IEnumerable<Order>> ListAsync(string query);
    //    Task<Order> GetAsync(string id);
    //    Task AddAsync(Order item);
    //    Task UpdateAsync(string id, Order item);
    //    Task DeleteAsync(string id);
    //}

}
