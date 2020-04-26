using CoreAPI.Models;
using CoreAPI.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Database
{
    public class MongoDB :IDatabase
    {
        MongoClient dbClient ;
        private IConfiguration iConfig;
        private ILogger _iLog;
      

        public MongoDB(IConfiguration iConfiguration, ILoggerFactory iLoggerFactory)
        {
             iConfig = iConfiguration;
            _iLog = iLoggerFactory.CreateLogger("CoreAPILogs") ;
          
            _iLog.LogInformation(iConfig["ConnectionStrings:MongoDBCstr"]);
            dbClient = new MongoClient(iConfig["ConnectionStrings:MongoDBCstr"]);
        }

        public bool Insert(BsonDocument bsonDoc,string collectionName)
        {
            var database = dbClient.GetDatabase("local");
            var collection = database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(bsonDoc);
            return true;
        }

        public bool Update(Employee emp, string collectionName)
        {
            emp.id = ObjectId.Empty;
            var database = dbClient.GetDatabase("local");
            var collection = database.GetCollection<Employee>(collectionName);
            var result = collection.FindOneAndReplace(x => x.EmpID == emp.EmpID, emp);
            return true;
        }

        public List<Employee> Get(string collectionName)
        {
            var database = dbClient.GetDatabase("local");
            var collection = database.GetCollection<Employee>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
