using System.Collections.Generic;
using MongoDB.Driver;
using System;

namespace CardsService.Model
{
    public class AuditRepository : IAuditRepository
    {
        private IMongoDatabase _db;
        private const string server = "mongodb://localhost:27017";
        private const string database = "cards";
        private const string collection = "audit";

        public AuditRepository()
        {
            var client = new MongoClient(server);
            _db = client.GetDatabase(database);
        }

        public IList<Audit> GetAll()
        {
            return _db.GetCollection<Audit>(collection)
                .Find(a => true)
                .ToList();
        }

        public IList<Audit> GetByCardId(int id)
        {
            return _db.GetCollection<Audit>(collection)
                .Find(a => a.CardId == id)
                .ToList();
        }

        public void Add(string details)
        {
            Audit audit = new Audit() { Details = details, Date = DateTime.UtcNow };
            _db.GetCollection<Audit>(collection).InsertOne(audit);
        }
    }
}
