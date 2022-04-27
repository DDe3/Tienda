using Newtonsoft.Json;
using Tienda.Exceptions;

namespace Tienda.Repository
{
    public class JsonClient
    {
        static String[] JSON_Clients =
        {
            @"{'id': 1725875569,
               'number': 'A12',
               'name': 'Daniel',
               'lastName': 'Doe',
               'firstPurchase': '0001-01-01T00:00:00',
               'lastPurchase': '0001-01-01T00:00:00',
               'purchases': []
            }",
            @"{'id': 1725875570,
               'number': 'A13',
               'name': 'Anabel',
               'lastName': 'Saw',
               'firstPurchase': '0001-01-01T00:00:00',
               'lastPurchase': '0001-01-01T00:00:00',
               'purchases': []
            }",
            @"{'id': 1725875571,
               'number': 'A14',
               'name': 'Francis',
               'lastName': 'Jobs',
               'firstPurchase': '0001-01-01T00:00:00',
               'lastPurchase': '0001-01-01T00:00:00',
               'purchases': []
            }"
        };

        static String UnregisteredClient = @"{
                 'purchases': null,
                 'id': 0,
                 'number': '00000000000',
                 'name': null,
                 'lastName': null,
                 'firstPurchase': '0001-01-01T00:00:00',
                 'lastPurchase': '0001-01-01T00:00:00'
            }";

        public static List<Client> GetAllClients()
        {
            List<Client> ClientList = new();
            foreach (String json in JSON_Clients)
            {
                Client? client = JsonConvert.DeserializeObject<Client>(json);
                if (client != null)
                {
                    ClientList.Add(client);
                }
            }
            return ClientList;
        }

        public static Client? GetClientById(Int16 id)
        {
            if (id == 0)
            {
                return JsonConvert.DeserializeObject<Client>(UnregisteredClient);
            } else
            {
                List<Client> clients = GetAllClients();
                foreach (Client client in clients)
                {
                    if (client.Id == id)
                    {
                        return client;
                    }
                }
                throw new ClientNotFoundException(id.ToString());
            }
        }


    }
}
