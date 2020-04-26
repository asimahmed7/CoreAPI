using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public interface IEmployeeRepo
    {

        Employee GetEmployee(string ID);

        Employee AddEmployee(Employee Emp);

        Employee UpdateEmployee(Employee Emp);

        List<Employee> ListEmployees();
    }
}
