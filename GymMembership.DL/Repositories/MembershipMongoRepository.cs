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
    public class MembershipMongoRepository : IMembershipRepository
    {
        private readonly IMongoCollection<Membership> _membership;

        public MembershipMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };
            _membership = database
                .GetCollection<Membership>(nameof(Membership), collectionSettings);
        }

        public async Task<IEnumerable<Membership>> GetAll()
        {
            return await
                _membership.Find(membership => true).ToListAsync();
        }

        public async Task<Membership?> GetById(Guid id)
        {
            var item = await _membership
                .Find(Builders<Membership>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Add(Membership membership)
        {
            await _membership.InsertOneAsync(membership);
        }

        public Task Delete(Guid id)
        {
            return _membership.DeleteOneAsync(x => x.Id == id);
        }

        public async Task Update(Membership membership)
        {
            var filter =
                Builders<Membership>.Filter.Eq(s => s.Id, membership.Id);
            var update = Builders<Membership>
                .Update.Set(s =>
                    s.Period, membership.Period).Set(p => p.Price, membership.Price);

            await _membership.UpdateOneAsync(filter, update);
        }

       
    }
}

