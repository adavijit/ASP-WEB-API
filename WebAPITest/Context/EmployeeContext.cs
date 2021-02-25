using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPITest.Models;

namespace WebAPITest.Context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> EmployeeSet { get; set; }
    }
}