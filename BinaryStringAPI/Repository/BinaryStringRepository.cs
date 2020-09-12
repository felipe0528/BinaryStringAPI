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
            bool valid = false;
            List<string> prefixes = GeneratePrefixes(binary.Name);
            var countCero = binary.Name.Count(x => x == '0');
            var countOne = binary.Name.Count(x => x == '1');

            var validPrefixes = true;
            foreach (var prefix in prefixes)
            {
                var prefixCountCero = prefix.Count(x => x == '0');
                var prefixCountOne = prefix.Count(x => x == '1');
                if (prefixCountOne< prefixCountCero)
                {
                    validPrefixes = false;
                }
            }

            if ((countCero== countOne) && validPrefixes)
            {
                valid = true;
            }
            return valid;
        }

        private List<string> GeneratePrefixes(string name)
        {
            List<string> list = new List<string>();
            for (int i = 1; i < name.Length; i++)
            {
                list.Add(name.Substring(0, i));
            }
            return list;
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
            binary.Valid = ValidateBinary(binary);

            ReplaceOneResult updateResult = await _context.BinaryStrings
                        .ReplaceOneAsync(
                            filter: g => g.Id == binary.Id,
                            replacement: binary);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
