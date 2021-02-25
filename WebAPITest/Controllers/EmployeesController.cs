using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebAPITest.Context;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();


        public IEnumerable<Employee> Get()
        {
             return db.EmployeeSet.ToList();
        }

        public IHttpActionResult Post(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var ctx = new EmployeeContext())
            {
                ctx.EmployeeSet.Add(new Employee()
                {
                    ID = employee.ID,
                    Name = employee.Name,
                    Salary = employee.Salary
                });

                ctx.SaveChanges();
            }

            return Ok("success");
        }



        // GET: Employees/Details/5


        public Employee Get(int id)
        {
            var employee = db.EmployeeSet.FirstOrDefault((p) => p.ID == id);
            return employee;
        }

        public IHttpActionResult Delete(int id)
        {
            var employee = db.EmployeeSet.Where(e => e.ID == id).FirstOrDefault();

            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();

            return Ok("success");
        }

        public IHttpActionResult Put(Employee employee)
        {
            var existingStudent = db.EmployeeSet.Where(e => e.ID == employee.ID).FirstOrDefault();


            if (existingStudent != null)
            {
                existingStudent.Name = employee.Name;
                existingStudent.Salary = employee.Salary;

                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            db.SaveChanges();

            return Ok("success");
        }

        // GET: Employees/Create


        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



    }
}
