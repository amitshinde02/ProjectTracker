using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackerServices.Repositories
{
    public class EmployeesRepository
    {
        private static ProjectTrackingDBEntities dataContext = new ProjectTrackingDBEntities();
        public static List<Employee> GetAllEmployees()
        {
            var query = from employee in dataContext.Employees
                        select employee;
            return query.ToList();
        }

        public static List<Employee> SearchEmployeeByName(string employeeName)
        {
            var query = from employee in dataContext.Employees
                        where employee.EmployeeName.Contains(employeeName)
                        select employee;

            return query.ToList();
        }

        public static Employee GetEmployeeByID(int employeeID)
        {
            var query = from employee in dataContext.Employees
                        where employee.EmployeeID == employeeID
                        select employee;

            return query.SingleOrDefault();
        }

        public static List<Employee> InsertEmployee (Employee e)
        {
            dataContext.Employees.Add(e);
            dataContext.SaveChanges();
            return GetAllEmployees();
        }

        public static List<Employee> UpdateEmployee (Employee e)
        {
            var emp = (from employee in dataContext.Employees
                      where employee.EmployeeID == e.EmployeeID
                      select employee).SingleOrDefault();
            if(emp!=null)
            {
                emp.EmployeeName = e.EmployeeName;
                emp.Designation = e.Designation;
                emp.ContactNo = e.ContactNo;
                emp.EMailID = e.EMailID;
                emp.ManagerID = e.ManagerID;
                emp.SkillSets = e.SkillSets;
                emp.ProjectTasks = e.ProjectTasks;
                dataContext.SaveChanges();
            }

            return GetAllEmployees();
        }

        public static List<Employee> DeleteEmployee (Employee e)
        {
            var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
            return GetAllEmployees();
        }
    }
}