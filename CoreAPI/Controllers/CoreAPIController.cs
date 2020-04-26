using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreAPI.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CoreAPIController : ControllerBase
    {
        private IEmployeeRepo iEmployeeRepo;
        private IConfiguration iConfig;

        public CoreAPIController(IEmployeeRepo IEmpRepo, IConfiguration iConfiguration)
        {
            iEmployeeRepo = IEmpRepo;
            iConfig = iConfiguration;
        }

        [HttpGet]
        public string GetResults()
        {
           
            return "Asim";
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(string ID)
        {

            return Ok(iEmployeeRepo.GetEmployee(ID));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddEmployee(Employee Emp)
        {

            return Ok(iEmployeeRepo.AddEmployee(Emp));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEmployee(Employee Emp)
        {

            return Ok(iEmployeeRepo.UpdateEmployee(Emp));

        }


        [HttpGet,HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListEmployees(string EmpID)
        {

            return Ok(iEmployeeRepo.ListEmployees());

        }
    }
}