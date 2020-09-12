using BinaryStringAPI.Data;
using BinaryStringAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Repository
{
    public class BinaryStringRepository : IBinaryStringRepository
    {
        private readonly IBinaryContext _context;

        public BinaryStringRepository(IBinaryContext context)
        {
            _context = context;
        }

        public async Task Create(BinaryString binary)
        {
            binary.Valid = ValidateBinary(binary);

            await _context.BinaryStrings.InsertOneAsync(binary);
        }

        private bool ValidateBinary(BinaryString binary)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<BinaryString> filter = Builders<BinaryString>
                .Filter.Eq(m => m.Name, name);

            DeleteResult deleteResult = await _context
                                                .BinaryStrings
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<BinaryString>> GetAllBinaryStrings()
        {
            return await _context.BinaryStrings
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<BinaryString> GetBinaryString(string name)
        {
            FilterDefinition<BinaryString> filter = Builders<BinaryString>
                .Filter.Eq(m => m.Name, name);

            return _context.BinaryStrings
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(BinaryString binary)
        {
            ReplaceOneResult updateResult = await _context.BinaryStrings
                        .ReplaceOneAsync(
                            filter: g => g.Id == binary.Id,
                            replacement: binary);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
