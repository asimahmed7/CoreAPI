using CoreAPI.MongoDB;
using CoreAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreAPI.DataAccess
{
    public class EmployeeDataAccess : IEmployeeRepo
    {
        private IDatabase _dbase;
        public EmployeeDataAccess(IDatabase dbase)
        {
            _dbase = dbase;

        }


        public Employee AddEmployee(Employee Emp)
        {

            string guid = Guid.NewGuid().ToString();

            var dictionary = new Dictionary<string, object>
                {
                   { "EmpID", guid }, {
                                "Name", Emp.Name }, { "Email", Emp.Email }, { "Department", Emp.Department},{ "Joiningdate", Emp.joiningdate},{ "Emptype", Emp.Emptype},{ "EmployeeSkills", Emp.EmployeeSkills}
                };

            var document = dictionary.ToBsonDocument();


            //    var document = new BsonDocument { { "EmpID", guid }, {
            //        "Name", Emp.Name }, { "Email", Emp.Email }, { "Department", Emp.Department},{ "EmployeeSkills", Newtonsoft.Json.JsonConvert.SerializeObject(Emp.EmployeeSkills)}
            //};

            _dbase.Insert(document, "Employee");

            Emp.EmpID = guid;
          
            return Emp;

            //throw new NotImplementedException();
        }

        public Employee UpdateEmployee(Employee Emp)
        {
            if (_dbase.Update(Emp, "Employee"))
            {
                return Emp;
            }
            else
            { return null; }

        }

        public Employee GetEmployee(string ID)
        {
            throw new NotImplementedException();
        }

       public  List<Employee> ListEmployees()
        {
            return _dbase.Get("Employee");
        }
    }
}
