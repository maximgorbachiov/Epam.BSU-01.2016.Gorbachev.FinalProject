using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ORM;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class ClientRepository : EntityRepository, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context) { }

        public DalClient GetClientById(int id)
        {
            return context.Set<Client>().FirstOrDefault(client => client.Id == id)?.ToDalClient();
        }

        public DalClient GetClientByEmail(string email)
        {
            return context.Set<Client>().FirstOrDefault(client => client.Email == email)?.ToDalClient();
        }

        public IEnumerable<DalClient> GetClientByName(string name)
        {
            var clients = context.Set<Client>().ToList();
            return clients.Where(client => client.Name == name).Select(client => client.ToDalClient());
        }

        public IEnumerable<DalClient> GetClientByPredicate(Expression<Func<DalClient, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalClient> GetAllClients()
        {
            var clients = context.Set<Client>().ToList();
            return clients.Select(client => client.ToDalClient());
        }

        public void CreateClient(DalClient client)
        {
            if (client == null) return;
            var newClient = client.ToClient();
            context.Set<Client>().Add(newClient);
        }

        public void RemoveClient(int id)
        {
            var client = context.Set<Client>().FirstOrDefault(t => t.Id == id);
            if (client == null) return;

            var passedTests = context.Set<PassedTest>()?.Where(passedTest => passedTest.ClientId == id).ToList();

            if (passedTests == null) return;

            foreach (var passedTest in passedTests)
            {
                if (passedTest == null) return;

                context.Set<PassedTest>().Remove(passedTest);
            }

            context.Set<Client>().Remove(client);
        }

        public void UpdateClient(DalClient dalClient)
        {
            var ormClient = context.Set<Client>().FirstOrDefault(client => client.Id == dalClient.Id);

            if (ormClient == null) return;

            ormClient.Name = dalClient.Name;
            ormClient.Surname = dalClient.Surname;
            ormClient.Patronymic = dalClient.Patronymic;
            ormClient.Age = dalClient.Age;
            ormClient.Email = dalClient.Email;
            ormClient.Password = dalClient.Password;
            context.Entry(ormClient).State = EntityState.Modified;
        }
    }
}
