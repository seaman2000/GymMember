using GymMembership.DL.Interfaces;
using GymMembership.Models.Configuration;
using GymMembership.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DL.Repositories

{
    public class ClientMongoRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _client;

        public ClientMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };
            _client = database
                .GetCollection<Client>(nameof(Client), collectionSettings);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await
                _client.Find(author => true).ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            var item = await _client
                .Find(Builders<Client>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Add(Client client)
        {
            await _client.InsertOneAsync(client);
        }

        public Task Delete(Guid id)
        {
            return _client.DeleteOneAsync(x => x.Id == id);
        }

        public Task Update(Client client)
        {
            var filter =
                Builders<Client>.Filter.Eq(s => s.Id, client.Id);
            var update = Builders<Client>
                .Update.Set(s => s.PhoneNumber, client.PhoneNumber).Set(a => a.Age, client.Age).Set(x => x.Name, client.Name);
            return _client.UpdateOneAsync(filter, update);
        }
    }
}



