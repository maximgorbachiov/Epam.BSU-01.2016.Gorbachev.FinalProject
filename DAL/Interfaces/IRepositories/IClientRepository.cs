using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface IClientRepository
    {
        DalClient GetClientById(int id);
        DalClient GetClientByEmail(string email);
        IEnumerable<DalClient> GetClientByPredicate(Expression<Func<DalClient, bool>> predicate);
        IEnumerable<DalClient> GetClientByName(string name);
        IEnumerable<DalClient> GetAllClients();
        void CreateClient(DalClient client);
        void UpdateClient(DalClient client);
        void RemoveClient(int id);
    }
}
