using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjectTrackerServices.Repositories;

namespace ProjectTrackerServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PTEmployeesController : ApiController
    {
        // GET: api/PTEmployees
        [Route("api/ptemployees")]
        public HttpResponseMessage Get()
        {
            var employees = EmployeesRepository.GetAllEmployees();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        // GET: api/PTEmployees/5
        [Route("api/ptemployees/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var employees = EmployeesRepository.GetEmployeeByID(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptemployees/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var employees = EmployeesRepository.SearchEmployeeByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }
        // POST: api/PTEmployees
        [Route("api/ptemployees")]
        public HttpResponseMessage Post(Employee e)
        {
            var employees = EmployeesRepository.InsertEmployee(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        // PUT: api/PTEmployees/5
        [Route("api/ptemployees")]
        public HttpResponseMessage Put(Employee e)
        {
            var employees = EmployeesRepository.UpdateEmployee(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptemployees")]
        public HttpResponseMessage Delete(Employee e)
        {
            var employees = EmployeesRepository.DeleteEmployee(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }
    }
}
