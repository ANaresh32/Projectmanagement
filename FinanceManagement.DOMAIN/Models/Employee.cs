using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DOMAIN.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string MobileNumber { get; set; }
        public string DateOfJoining {  get; set; }
        public string Department { get; set; }
        public int ProjectManagerId { get; set; }
        public string EmployeeStatus { get; set; }
        public string SkillSet {  get; set; }
        public int RoleId { get; set; }
        //public Roles Roles { get; set; }
    }
}
