namespace DomainLayer.Service
{
    using System.Collections.Generic;

    using DomainLayer.Interfaces;
    using DomainLayer.Types;

    using Ninject;

    public class OrganizationService
    {
        [Inject]
        private IRepository<Organization, int> _organizationsRepository;

        public Organization RegisterOrganization(string name, string endpoint)
        {
            Organization org = new Organization{ EndPoint = endpoint, Name = name };
            _organizationsRepository.Add(org);
            return org;
        }

        public Organization GetById(int id)
        {
            return _organizationsRepository.GetById(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizationsRepository.GetAll();
        }
    }
}