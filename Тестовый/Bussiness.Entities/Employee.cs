using System;

namespace MyApp.Web.Api.Bussiness.Entities
{
    public class Employee
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public long  Id { get; set; }
    }
}
