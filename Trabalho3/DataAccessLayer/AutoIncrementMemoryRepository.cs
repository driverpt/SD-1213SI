namespace DataAccessLayer
{
    using System.Collections.Generic;

    using DomainLayer.Interfaces;

    public class AutoIncrementMemoryRepository<T> : BaseMemoryRepository<T, int> where T : IDomainModel<int>
    {
        private volatile int _currentId;

        private static readonly IDictionary<int, T> Repo = new Dictionary<int, T>();

        public AutoIncrementMemoryRepository()
            : base(Repo)
        {
            this._currentId = Repo.Keys.Count;
        }

        public override IRepository<T, int> Add(T obj)
        {
            int newId = ++this._currentId;
            obj.Id = newId;
            this._repo.Add(newId, obj);
            return this;
        }
    }
}