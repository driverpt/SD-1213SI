namespace DomainLayer.Service
{
    using System.Collections.Generic;

    using DomainLayer.Interfaces;
    using DomainLayer.Types;

    using Ninject;

    public class SuppliersService
    {
        [Inject]
        private IRepository<Supplier, string> _suppliersRepository;

        public IEnumerable<Supplier> GetAll()
        {
            return _suppliersRepository.GetAll();
        }

        public Supplier GetByName(string name)
        {
            return _suppliersRepository.GetById(name);
        }
    }

}