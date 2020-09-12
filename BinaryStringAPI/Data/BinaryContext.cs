using BinaryStringAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Data
{
    public class BinaryContext : IBinaryContext
    {
        private readonly IMongoDatabase _db;

        public BinaryContext(IOptions<Settings> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<BinaryString> BinaryStrings => _db.GetCollection<BinaryString>("BinaryStrings");
    }
}
