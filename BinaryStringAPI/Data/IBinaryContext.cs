using BinaryStringAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Data
{
    public interface IBinaryContext
    {
        IMongoCollection<BinaryString> BinaryStrings { get; }
    }
}
