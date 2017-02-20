using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackerServices.Repositories
{
    public class ProjectsRepository
    {
        private static ProjectTrackingDBEntities datacontext = new ProjectTrackingDBEntities();

        public static List<Project> GetAllProjects()
        {
            var query = from project in datacontext.Projects
                        select project;

            return query.ToList();
        }

        public static List<Project> SearchProjectByName(string projectName)
        {
            var query = from project in datacontext.Projects
                        where project.ProjectName == projectName
                        select project;

            return query.ToList();
        }

        public static Project GetProjectByID(int projectID)
        {
            var query = from project in datacontext.Projects
                        where project.ProjectID == projectID
                        select project;

            return query.SingleOrDefault();
        }

        public static List<Project> InsertProject(Project p)
        {
            datacontext.Projects.Add(p);
            datacontext.SaveChanges();
            return GetAllProjects();
        }

        public static List<Project> UpdateProject(Project p)
        {
            var project = (from proj in datacontext.Projects
                           where proj.ProjectID == p.ProjectID
                           select proj).SingleOrDefault();

            if (project != null)
            {
                project.ClientName = p.ClientName;
                project.EndDate = p.EndDate;
                project.ProjectName = p.ProjectName;
                project.StartDate = p.StartDate;
                project.UserStories = p.UserStories;

                datacontext.SaveChanges();

            }

            return GetAllProjects();
        }

        public static List<Project> DeleteProject(Project p)
        {
            var project = (from proj in datacontext.Projects
                           where proj.ProjectID == p.ProjectID
                           select proj).SingleOrDefault();

            datacontext.Projects.Remove(project);
            datacontext.SaveChanges();
            return GetAllProjects();
        }
    }
}