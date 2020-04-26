using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    //[BsonIgnoreExtraElements]
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [IgnoreDataMember]
        public ObjectId id { get; set; }

        [DataMember]
        [BsonElement("EmpID")]
        public string EmpID { get; set; }

        [DataMember]
        [Required]
        [BsonElement("Name")]
        public string Name { get; set; }

        [DataMember]
        [BsonElement("Email")]
        public string Email { get; set; }

        [DataMember]
        [BsonElement("Department")]
        public string Department { get; set; }

        [DataMember]
        [BsonElement("Joiningdate")]
        public DateTime joiningdate { get; set; }

        [DataMember]
        [BsonElement("Emptype")]
        public string Emptype { get; set; }

        [DataMember]
        [BsonElement("EmployeeSkills")]
        public List<Skills> EmployeeSkills { get; set; }

    }


    public class Skills
    {
        public string skillName { get; set; }
        public string Level { get; set; }

    }
}
