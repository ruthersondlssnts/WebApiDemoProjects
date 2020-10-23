using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeDataAccess.Context;
using EmployeeDataAccess.Entities;

namespace EmployeeService2.Controllers
{
    //[EnableCors("https://localhost:44392", "*", "*")]
    //[RequireHttps]
    [Authorize]
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDbContext context = new EmployeeDbContext())
            {
                return context.Employees.ToList();
            }
        }


        //[BasicAuthentication]
        ////[DisableCors]
        //public HttpResponseMessage Get(string gender = "All")
        //{
        //    string username = Thread.CurrentPrincipal.Identity.Name;
        //    using (EmployeeDbContext context = new EmployeeDbContext())
        //    {
        //        switch (username.ToLower())
        //        {
        //            //case "all":
        //            //    return Request.CreateResponse(HttpStatusCode.OK, context.Employees.ToList());
        //            case "male":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    context.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
        //            case "female":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    context.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
        //            default:
        //                return Request.CreateResponse(HttpStatusCode.BadRequest);
        //                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
        //                //    "Value for gender must be All, Male or Female." + gender + " is invalid.");
        //        }
        //    }
        //}
        //[HttpGet]
        //public HttpResponseMessage LoadEmployeeById(int id)
        //{
        //    using (EmployeeDbContext context = new EmployeeDbContext())
        //    {
        //        var entity = context.Employees.FirstOrDefault(e => e.Id == id);

        //        return entity != null ?
        //            Request.CreateResponse(HttpStatusCode.OK, entity) :
        //            Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id.ToString() + " Not Found");
        //    }
        //}

        //public HttpResponseMessage Post([FromBody] Employee employee)
        //{

        //    try
        //    {
        //        using (EmployeeDbContext context = new EmployeeDbContext())
        //        {
        //            context.Employees.Add(employee);
        //            context.SaveChanges();

        //            var message = Request.CreateResponse(HttpStatusCode.Created, employee);
        //            message.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());
        //            return message;
        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
        //    }
        //}

        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        using (EmployeeDbContext context = new EmployeeDbContext())
        //        {
        //            var entity = context.Employees.FirstOrDefault(e => e.Id == id);
        //            if (entity != null)
        //            {
        //                context.Employees.Remove(entity);
        //                context.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }

        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id.ToString() + " not found to delete");

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

        //    }
        //}

        //public HttpResponseMessage Put([FromBody] int id, [FromUri] Employee employee)
        //{
        //    try
        //    {
        //        using (EmployeeDbContext context = new EmployeeDbContext())
        //        {
        //            var entity = context.Employees.FirstOrDefault(e => e.Id == id);
        //            if (entity != null)
        //            {
        //                entity.FirstName = employee.FirstName;
        //                entity.LastName = employee.LastName;
        //                entity.Gender = employee.Gender;
        //                entity.Salary = employee.Salary;

        //                context.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }

        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id.ToString() + " not found to update");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
        //    }
        //}
    }
}
