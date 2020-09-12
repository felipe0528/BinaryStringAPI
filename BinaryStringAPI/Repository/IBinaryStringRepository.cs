using BinaryStringAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Repository
{
    public interface IBinaryStringRepository
    {
        Task<IEnumerable<BinaryString>> GetAllBinaryStrings();
        Task<BinaryString> GetBinaryString(string name);
        Task Create(BinaryString game);
        Task<bool> Update(BinaryString game);
        Task<bool> Delete(string name);
    }
}
