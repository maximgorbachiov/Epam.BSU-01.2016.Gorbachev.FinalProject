using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IClientService
    {
        ClientEntity GetClientEntity(int id);
        ClientEntity GetClientByEmail(string email);
        IEnumerable<ClientEntity> GetClientsByName(string name);
        IEnumerable<ClientEntity> GetAllClientEntities();
        void CreateClient(ClientEntity client);
        void UpdateClient(ClientEntity client);
        void DeleteClient(ClientEntity client);
    }
}
