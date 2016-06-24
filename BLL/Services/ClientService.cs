using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ClientService : EntityService, IClientService
    {
        public ClientService(IUnitOfWork uow) : base(uow) { }

        public ClientEntity GetClientEntity(int id)
        {
            return uow.Clients.GetClientById(id)?.ToBllClient();
        }

        public ClientEntity GetClientByEmail(string email)
        {
            return uow.Clients.GetClientByEmail(email)?.ToBllClient();
        }

        public IEnumerable<ClientEntity> GetClientsByName(string name)
        {
            return uow.Clients.GetClientByName(name)?.Select(dalClient => dalClient.ToBllClient());
        }

        public IEnumerable<ClientEntity> GetAllClientEntities()
        {
            return uow.Clients.GetAllClients()?.Select(dalClient => dalClient.ToBllClient());
        }

        public void CreateClient(ClientEntity client)
        {
            uow.Clients.CreateClient(client?.ToDalClient());
            uow.Commit();
        }

        public void DeleteClient(ClientEntity client)
        {
            if (client == null) return;

            uow.Clients.RemoveClient(client.ToDalClient().Id);
            uow.Commit();
        }

        public void UpdateClient(ClientEntity client)
        {
            uow.Clients.UpdateClient(client?.ToDalClient());
            uow.Commit();
        }
    }
}
