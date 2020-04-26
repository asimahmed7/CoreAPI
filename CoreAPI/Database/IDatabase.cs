using CoreAPI.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.MongoDB
{
    public interface IDatabase
    {

        bool Insert(BsonDocument bsonDoc,string collectionName);
        bool Update(Employee emp, string collectionName);
        List<Employee> Get(string collectionName);
    }
}
