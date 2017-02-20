using ProjectTrackerServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectTrackerServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PTProjectsController : ApiController
    {
        // GET: api/PTProjects
        [Route("api/ptprojects")]
        public HttpResponseMessage Get()
        {
            var projects = ProjectsRepository.GetAllProjects();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }

        // GET: api/PTProjects/5
        [Route("api/ptprojects/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var projects = ProjectsRepository.GetProjectByID(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }

        [Route("api/ptprojects/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var projects = ProjectsRepository.SearchProjectByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }

        // POST: api/PTProjects
        [Route("api/ptprojects/")]
        public HttpResponseMessage Post(Project project)
        {
            var projects = ProjectsRepository.InsertProject(project);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }

        [Route("api/ptprojects/")]
        public HttpResponseMessage Put(Project project)
        {
            var projects = ProjectsRepository.UpdateProject(project);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }
        // DELETE: api/PTProjects/5

        [Route("api/ptprojects/")]
        public HttpResponseMessage Delete(Project project)
        {
            var projects = ProjectsRepository.DeleteProject(project);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
            return response;
        }
    }
}
