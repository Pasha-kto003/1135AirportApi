using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Client
    {
        public static explicit operator ClientApi(Client client)
        {
            return new ClientApi { 
                 Id = client.Id, 
                 FirstName = client.FirstName,
                 Patronymic = client.Patronymic,
                 LastName = client.LastName,
                 IdPassport = client.IdPassport
            };
        }

        public static explicit operator Client(ClientApi client)
        {
            return new Client
            {
                Id = client.Id,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                LastName = client.LastName,
                IdPassport = client.IdPassport
            };
        }
    }
}
