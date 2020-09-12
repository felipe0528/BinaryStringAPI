using BinaryStringAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Repository
{
    public class BinaryStringRepository : IBinaryStringRepository
    {
        public Task Create(BinaryString game)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BinaryString>> GetAllBinaryStrings()
        {
            throw new NotImplementedException();
        }

        public Task<BinaryString> GetBinaryString(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BinaryString game)
        {
            throw new NotImplementedException();
        }
    }
}
