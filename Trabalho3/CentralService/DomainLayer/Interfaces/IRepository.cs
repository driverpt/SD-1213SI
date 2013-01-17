namespace DomainLayer.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T, K> where T : IDomainModel<K>
    {
        IEnumerable<T> GetAll();
        T GetById(K id);
        IRepository<T, K> Add(T obj);
    }
}
